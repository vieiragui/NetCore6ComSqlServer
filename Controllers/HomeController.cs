using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BlogSemEntity.Models;
using BlogSemEntity.Repository.Interfaces;
using BlogSemEntity.Repository;
using BlogSemEntity.ViewModel;

namespace BlogSemEntity.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IBaseRepository<Usuario> _usuarioRepository;

    public HomeController(ILogger<HomeController> logger, IBaseRepository<Usuario> usuarioRepository)
    {
        _logger = logger;
        _usuarioRepository = usuarioRepository;
    }

    public async Task<IActionResult> Index()
    {
        var listaUsuario = await _usuarioRepository.Select();
        return View(listaUsuario);
    }

    public async Task<IActionResult> Adicionar()
    {
        await Task.Yield();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Adicionar(UsuarioViewModel modelo)
    {
        var novoUsuario = new Usuario(modelo.Nome, modelo.Email);
        await _usuarioRepository.Insert(novoUsuario);

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Atualizar(int id, string nome, string email)
    {
        var usuario = await _usuarioRepository.SelectPerId(id);
        usuario.Nome = nome;
        usuario.Email = email;

        await _usuarioRepository.Update(usuario);

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Remover(string id)
    {
        var usuario = await _usuarioRepository.SelectPerId(int.Parse(id));
        await _usuarioRepository.Remove(usuario);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
