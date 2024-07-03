using API.Biblioteca.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>();

builder.Services.AddCors(
    options => options.AddPolicy("Acesso Total", configs => configs.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod())
);
var app = builder.Build();

app.MapGet("/", () => "API de Biblioteca");


//CRUD USUARIO

app.MapPost("/usuario/cadastrar/", ([FromBody] Usuario usuario, [FromServices] AppDbContext ctx) =>
{
     Usuario? usuarioBuscado = ctx.TabelaUsuarios.FirstOrDefault(x => x.Nome == usuario.Nome);
     if (usuarioBuscado is null)
     {
          ctx.TabelaUsuarios.Add(usuario);
          ctx.SaveChanges();
          return Results.Created("Cadastro realizado!!", usuario);
     }
     return Results.BadRequest("Já existe um usuário igual!!");
});

app.MapGet("/usuario/listar/", ([FromServices] AppDbContext ctx) =>
{
     if (ctx.TabelaUsuarios.Any())
     {
          return Results.Ok(ctx.TabelaUsuarios.ToList());
     }
     return Results.NotFound("Não existe usuários cadastrados!");
});

app.MapDelete("/usuario/deletar/{id}", ([FromRoute] string id, [FromServices] AppDbContext ctx) =>
{
     Usuario usuario = ctx.TabelaUsuarios.FirstOrDefault(x => x.UsuarioId == id);
     if (usuario is null)
     {
          return Results.NotFound("Usuário não encontrado");
     }
     ctx.TabelaUsuarios.Remove(usuario);
     ctx.SaveChanges();
     return Results.Ok("Usuário removido com suscesso!!");
});

//CRUD LIVRO
// Cadastrar um novo livro
app.MapPost("/livro/cadastrar/", ([FromBody] Livro livro, [FromServices] AppDbContext ctx) =>
{
     Livro livroBuscado = ctx.TabelaLivros.FirstOrDefault(x => x.Titulo == livro.Titulo);
     if (livroBuscado == null)
     {
          ctx.TabelaLivros.Add(livro);
          ctx.SaveChanges();
          return Results.Created("Cadastro de livro realizado!!", livro);
     }
     return Results.BadRequest("Já existe um livro igual!!");
});

// Listar todos os livros
app.MapGet("/livro/listar/", async ([FromServices] AppDbContext ctx) =>
{
     // Use Include para carregar entidades Avaliacao
     var livrosComAvaliacoes = await ctx.TabelaLivros
         .Include(l => l.Avaliacoes)
         .Include(l => l.Comentarios)
         .ToListAsync();

     if (livrosComAvaliacoes.Any())
     {
          return Results.Ok(livrosComAvaliacoes);
     }

     return Results.NotFound("Não existem livros cadastrados!");
});


// Buscar livro por título, autor ou categoria
app.MapPost("/livro/buscar", ([FromBody] Livro livro, [FromServices] AppDbContext ctx) =>
{
     var query = ctx.TabelaLivros.AsQueryable();

     if (!string.IsNullOrEmpty(livro.Titulo))
     {
          query = query.Where(l => l.Titulo.Contains(livro.Titulo));
     }
     if (!string.IsNullOrEmpty(livro.Autor))
     {
          query = query.Where(l => l.Autor.Contains(livro.Autor));
     }
     if (!string.IsNullOrEmpty(livro.Categoria))
     {
          query = query.Where(l => l.Categoria.Contains(livro.Categoria));
     }

     var livrosFiltrados = query.ToList();

     if (livrosFiltrados.Any())
     {
          return Results.Ok(livrosFiltrados);
     }
     else
     {
          return Results.NotFound("Nenhum livro encontrado com os critério de busca fornecidos.");
     }

});


// Deletar um livro por ID
app.MapDelete("/livro/deletar/{id}", ([FromRoute] string id, [FromServices] AppDbContext ctx) =>
{
     Livro livro = ctx.TabelaLivros.FirstOrDefault(x => x.LivroId == id);
     if (livro != null)
     {
          ctx.TabelaLivros.Remove(livro);
          ctx.SaveChanges();
          return Results.Ok("Livro removido com sucesso!!");
     }
     return Results.NotFound("Livro não encontrado");
});

// Alterar Livro
app.MapPut("/livro/alterar/{id}", ([FromRoute] string id,
    [FromBody] Livro livroAlterado,
    [FromServices] AppDbContext ctx) =>
{
     Livro? livro = ctx.TabelaLivros.Find(id);
     if (livro is null)
     {
          return Results.NotFound("Produto não encontrado!");
     }
     livro.Titulo = livroAlterado.Titulo;
     livro.Categoria = livroAlterado.Categoria;
     livro.Autor = livroAlterado.Autor;
     ctx.TabelaLivros.Update(livro);
     ctx.SaveChanges();
     return Results.Ok("Livro alterado!");

});

//Avaliar um livro
app.MapPost("/livro/{id}/avaliar/", async ([FromRoute] string id, [FromBody] Avaliacao avaliacao, [FromServices] AppDbContext ctx) =>
{
     // Use Include para carregar entidades Avaliacao
     var livroBuscado = await ctx.TabelaLivros
         .Include(l => l.Avaliacoes)
         .FirstOrDefaultAsync(l => l.LivroId == id);

     if (livroBuscado != null)
     {
          livroBuscado.Avaliacoes.Add(avaliacao);
          await ctx.SaveChangesAsync();
          return Results.Ok("Avaliação adicionada com sucesso!!");
     }

     return Results.NotFound("Livro não encontrado");
});


// Comentar um livro
app.MapPost("/livro/{id}/comentar/", async ([FromRoute] string id, [FromBody] Comentario comentario, [FromServices] AppDbContext ctx) =>
{
     var livroBuscado = await ctx.TabelaLivros
          .Include(l => l.Comentarios)
          .FirstOrDefaultAsync(l => l.LivroId == id);
     if (livroBuscado != null)
     {
          livroBuscado.Comentarios.Add(comentario);
          ctx.SaveChanges();
          return Results.Ok("Comentário adicionado com sucesso!!");
     }
     return Results.NotFound("Livro não encontrado");
});

// CRUD EMPRESTIMO

// Registrar emprestimo
app.MapPost("/emprestimo/registrar/{emprestado}/{id}", async ([FromRoute] bool emprestado, [FromRoute] string id, [FromBody] Emprestimo emprestimo, [FromServices] AppDbContext ctx) =>
{
     try
     {
          DateTime dataAtual = DateTime.Now;

          Livro livroBuscado = ctx.TabelaLivros.FirstOrDefault(l => l.LivroId == id && l.Emprestado == true);
          if (livroBuscado != null)
          {
               return Results.BadRequest("Livro já está emprestado.");
          }
          var liv = ctx.TabelaLivros.Find(emprestimo.LivroId);
          liv.Emprestado = true;

          emprestimo.EmprestimoId = Guid.NewGuid().ToString();
          emprestimo.DataEmprestimo = dataAtual;

          ctx.TabelaEmprestimos.Add(emprestimo);

          await ctx.SaveChangesAsync();

          return Results.Created("Emprestimo realizado!", emprestimo);
     }
     catch (Exception ex)
     {
          return Results.Problem("Ocorreu um erro ao registrar o empréstimo. Por favor, tente novamente mais tarde.");
     }
});


// Listar emprestimos
app.MapGet("/emprestimo/listar", ([FromServices] AppDbContext ctx) =>
{
     var emprestimos = ctx.TabelaEmprestimos
          .Include(e => e.Usuario) // Inclui informações do usuário
          .Include(e => e.Livro) // Inclui informações do livro
          .Where(e => e.Livro != null && e.Livro.Emprestado == true) // Filtra por livros emprestados
          .ToList();

     if (emprestimos.Any())
     {
          return Results.Ok(emprestimos); // Retorna empréstimos filtrados
     }

     return Results.NotFound("Não existem empréstimos com livros emprestados!"); // Informa que nenhum empréstimo foi encontrado
});


//CRUD Devolução

//Registrar Devolução

app.MapPost("/devolucao/registrar/{id}",  ([FromBody] Devolucao devolucao, [FromRoute] string id, [FromServices] AppDbContext ctx) =>
{
     // Encontrar o empréstimo com base no usuário e livro
     var emprestimo = ctx.TabelaEmprestimos.FirstOrDefault(e => e.UsuarioId == devolucao.UsuarioId && e.LivroId == devolucao.LivroId);
     if (emprestimo == null)
     {
          return Results.NotFound("Empréstimo não encontrado.");
     }

     // Find the book
     Livro livro = ctx.TabelaLivros.Find(devolucao.LivroId);
     if (livro == null)
     {
          return Results.BadRequest("Livro não encontrado.");
     }

     // Check if the book is currently loaned out
     if (!livro.Emprestado == true)
     {
          return Results.BadRequest("O livro já está disponível.");
     }

          var livroDev = ctx.TabelaLivros.Find(devolucao.LivroId);
          // Update the book status to not loaned out
          livroDev.Emprestado = false;

          ctx.TabelaDevolucao.Add(devolucao);

          ctx.SaveChanges();

          return Results.Ok("Livro devolvido com sucesso.");


});



//Listar Devolução 

app.MapGet("devolucao/listar", ([FromServices] AppDbContext ctx) =>
{
     var devolucoes = ctx.TabelaDevolucao.ToList();
     if (devolucoes.Any())
     {
          return Results.Ok(devolucoes);
     }
     return Results.NotFound("Não existem devoluções cadastradas!");
});

//Realizar Login

app.MapPost("usuario/login", ([FromServices] AppDbContext ctx, [FromBody] Usuario usuario) =>
{
     Usuario usuarioExiste = ctx.TabelaUsuarios.FirstOrDefault(e => e.Email == usuario.Email && e.Senha == usuario.Senha);
     Permissao permissao = usuarioExiste.Permissao;
     if (usuarioExiste != null)
     {
          var usu = usuarioExiste.Email;
          var usuId = usuarioExiste.UsuarioId;
          return Results.Ok(new LoginResponse { Success = true, Message = "Login efetuado com sucesso!", Permissao = permissao, Usuario = usu, UsuarioId = usuId });
     }
     else
     {
          return Results.NotFound(new LoginResponse { Success = false, Message = "Usuário ou senha incorretos.", Permissao = permissao });
     }
});






app.UseCors("Acesso Total");
app.Run();
