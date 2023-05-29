using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using lab_vinfinita.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;

namespace lab_vinfinita.Controllers
{
    
    public class VinhosController : Controller
    {
        private readonly ProjetoContext _context;
        private readonly IHostingEnvironment _he;

        public VinhosController(ProjetoContext context, IHostingEnvironment e)
        {
            _context = context;
            _he = e;
        }

        [Authorize(Roles = "Administrador,Garrafeira")]
        // GET: Vinhos
        public async Task<IActionResult> ListagemGarrafeira(Possuir possuir)
        {
            var email_user = HttpContext.Session.GetString("Current_user");

            int id_gar = -1;

            foreach (var item in _context.Utilizador)
            {
                if (item.Email == email_user)
                {
                    id_gar = item.IdUtilizador;
                }
            }

            ViewBag.idgar = id_gar;

            string nomeprod = "";

            foreach (var item in _context.Produtor)
            {
                if (item.IdProdutor == possuir.IdProdutor)
                {
                    nomeprod = item.NomeProdutor;
                }
            }
            ViewBag.nomeprodutor = nomeprod;

            string nomereg = "";

            foreach (var item in _context.Regiao)
            {
                if (item.IdRegiao == possuir.IdRegiao)
                {
                    nomereg = item.NomeRegiao;
                }
            }
            ViewBag.nomeregiao = nomereg;

            string nometip = "";

            foreach (var item in _context.Tipo)
            {
                if (item.IdTipo == possuir.IdTipo)
                {
                    nometip = item.NomeTipo;
                }
            }
            ViewBag.nometipo = nometip;

            return View(await _context.Vinho.ToListAsync());
        }

        [Authorize(Roles ="Administrador,Garrafeira,Cliente")]
        // GET: Vinhos/Details/5
        public async Task<IActionResult> Detalhes(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vinho = await _context.Vinho
                .FirstOrDefaultAsync(m => m.IdVinho == id);
            if (vinho == null)
            {
                return NotFound();
            }

            return View(vinho);
        }

        [Authorize(Roles ="Garrafeira")]
        // GET: Vinhos/Create
        public IActionResult CriarVinho()
        {
            ViewData["IdProdutor"] = new SelectList(_context.Produtor, "IdProdutor", "NomeProdutor");
            ViewData["IdRegiao"] = new SelectList(_context.Regiao, "IdRegiao", "NomeRegiao");
            ViewData["IdTipo"] = new SelectList(_context.Tipo, "IdTipo", "NomeTipo");

            return View();
        }

        // POST: Vinhos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CriarVinho([Bind("IdVinho,NomeVinho,Capacidade,FotoFrente,FotoTras,FotoRotulo,TeorAlcoolico,Castas,AnoProducao,Preco,Stock,IdProdutor,IdRegiao,IdTipo")] Vinho vinho, [Bind("ID_Garrafeira,ID,Vinho,Preco,Stock,DataInsercao")] Inserir inserir, [Bind("IdVinho,IdTipo,IdProdutor,IdRegiao")] Possuir possuir,IFormFile FotoF, IFormFile FotoT, IFormFile FotoR)
        {
            if (ModelState.IsValid)
            {
                if (!VinhoExists(vinho.IdVinho))
                {
                    var caminho_frente = Path.Combine(_he.WebRootPath + "/fotos", Path.GetFileName(FotoF.FileName));

                    FileStream fs_frente = new FileStream(caminho_frente, FileMode.Create);
                    FotoF.CopyTo(fs_frente);
                    fs_frente.Close();

                    var caminho_tras = Path.Combine(_he.WebRootPath + "/fotos", Path.GetFileName(FotoF.FileName));

                    FileStream fs_tras = new FileStream(caminho_frente, FileMode.Create);
                    FotoT.CopyTo(fs_tras);
                    fs_tras.Close();

                    var caminho_rotulo = Path.Combine(_he.WebRootPath + "/fotos", Path.GetFileName(FotoF.FileName));

                    FileStream fs_rotulo = new FileStream(caminho_rotulo, FileMode.Create);
                    FotoR.CopyTo(fs_rotulo);
                    fs_rotulo.Close();

                    vinho.FotoFrente = Path.GetFileName(FotoF.FileName);
                    vinho.FotoTras = Path.GetFileName(FotoT.FileName);
                    vinho.FotoRotulo = Path.GetFileName(FotoR.FileName);

                    _context.Vinho.Add(vinho);
                    await _context.SaveChangesAsync();

                    possuir.IdVinho = vinho.IdVinho;
                    possuir.IdProdutor = vinho.IdProdutor;
                    possuir.IdTipo = vinho.IdTipo;
                    possuir.IdRegiao = vinho.IdRegiao;

                    _context.Possuir.Add(possuir);
                    await _context.SaveChangesAsync();

                    var email_user = HttpContext.Session.GetString("Current_user");

                    int id_gar = -1;

                    foreach (var item in _context.Utilizador)
                    {
                        if (item.Email == email_user)
                        {
                            id_gar = item.IdUtilizador;
                        }
                    }

                    inserir.IdGarrafeira = id_gar;
                    inserir.IdVinho = vinho.IdVinho;
                    inserir.Preco = vinho.Preco;
                    inserir.Stock = vinho.Stock;
                    inserir.DataInsercao = DateTime.Now;
                    _context.Inserir.Add(inserir);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(ListagemGarrafeira));
                }
                else
                {
                    var email_user = HttpContext.Session.GetString("Current_user");

                    possuir.IdVinho = vinho.IdVinho;
                    possuir.IdProdutor = vinho.IdProdutor;
                    possuir.IdTipo = vinho.IdTipo;
                    possuir.IdRegiao = vinho.IdRegiao;

                    _context.Possuir.Add(possuir);
                    await _context.SaveChangesAsync();

                    int id_gar = -1;

                    foreach (var item in _context.Utilizador)
                    {
                        if (item.Email == email_user)
                        {
                            id_gar = item.IdUtilizador;
                        }
                    }
                   
                    inserir.IdGarrafeira = id_gar;
                    inserir.IdVinho = vinho.IdVinho;
                    inserir.Preco = vinho.Preco;
                    inserir.Stock = vinho.Stock;
                    inserir.DataInsercao = DateTime.Now;
                    _context.Inserir.Add(inserir);
                    await _context.SaveChangesAsync();



                    return RedirectToAction(nameof(ListagemGarrafeira));
                }
               
            }

            return View(vinho);
        }

        [Authorize(Roles ="Garrafeira")]
        public async Task<IActionResult> AtualizarPreco(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vinho = await _context.Vinho.FindAsync(id);
            if (vinho == null)
            {
                return NotFound();
            }
            return View(vinho);
        }

        // POST: Vinhos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AtualizarPreco(int id, [Bind("IdVinho,NomeVinho,Capacidade,FotoFrente,FotoTras,FotoRotulo,TeorAlcoolico,Castas,AnoProducao")] Vinho vinho, [Bind("ID_Garrafeira,ID,Vinho,Preco,Stock,DataInsercao")] Inserir inserir)
        {
            if (id != vinho.IdVinho)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var email_user = HttpContext.Session.GetString("Current_user");

                    int id_gar = -1;

                    foreach (var item in _context.Utilizador)
                    {
                        if (item.Email == email_user)
                        {
                            id_gar = item.IdUtilizador;
                        }
                    }

                    inserir.IdGarrafeira = id_gar;
                    inserir.IdVinho = vinho.IdVinho;
                    inserir.Preco = vinho.Preco;
                    _context.Update(inserir);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VinhoExists(vinho.IdVinho))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ListagemGarrafeira));
            }

            return View(vinho);
        }

        //CATÁLOGO
        [AllowAnonymous]
        public async Task<IActionResult> Catalogo()
        {
            var vin = _context.Vinho; //.Include(r => r.Possuir.IdProdutorNavigation).Include(r => r.Possuir.IdRegiaoNavigation).Include(r => r.Possuir.IdTipoNavigation);

            return View(await vin.ToListAsync());
        }


        [Authorize(Roles ="Administrador,Cliente,Garrafeira")]
        //Vinhos Premiados
        public async Task<IActionResult> Top()
        {
            var vin = _context.Vinho.Include(r => r.Possuir.IdProdutorNavigation).Include(r => r.Possuir.IdRegiaoNavigation).Include(r => r.Possuir.IdTipoNavigation);
            return View(await vin.ToListAsync());
        }



        [Authorize(Roles ="Garrafeira")]
        public async Task<IActionResult> AtualizarStock(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vinho = await _context.Vinho.FindAsync(id);
            if (vinho == null)
            {
                return NotFound();
            }
            return View(vinho);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AtualizarStock(int id, [Bind("IdVinho,NomeVinho,Capacidade,FotoFrente,FotoTras,FotoRotulo,TeorAlcoolico,Castas,AnoProducao")] Vinho vinho, [Bind("ID_Garrafeira,ID,Vinho,Preco,Stock,DataInsercao")] Inserir inserir)
        {
            if (id != vinho.IdVinho)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    inserir.IdVinho = vinho.IdVinho;
                    inserir.Stock = vinho.Stock;
                    _context.Update(inserir);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VinhoExists(vinho.IdVinho))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ListagemGarrafeira));
            }
            return View(vinho);
        }

        [Authorize(Roles ="Garrafeira")]
        // GET: Vinhos/Delete/5
        public async Task<IActionResult> ApagarVinho(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vinho = await _context.Vinho
                .FirstOrDefaultAsync(m => m.IdVinho == id);
            if (vinho == null)
            {
                return NotFound();
            }

            return View(vinho);
        }

        // POST: Vinhos/Delete/5
        [HttpPost, ActionName("ApagarVinho")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vinho_inserido = await _context.Vinho.FindAsync(id);

            Inserir inserir = new Inserir { IdVinho = vinho_inserido.IdVinho, Preco = vinho_inserido.Preco, Stock = vinho_inserido.Stock, DataInsercao = vinho_inserido.DataInsercao };

            _context.Inserir.Remove(inserir);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListagemGarrafeira));
        }

        private bool VinhoExists(int id)
        {
            return _context.Vinho.Any(e => e.IdVinho == id);
        }

        private bool ProdutorExists(string nome)
        {
            return _context.Produtor.Any(p=>p.NomeProdutor == nome);
        }

        private bool RegiaoExists(string nome)
        {
            return _context.Regiao.Any(p => p.NomeRegiao == nome);
        }

        private bool TipoExists(string nome)
        {
            return _context.Tipo.Any(p => p.NomeTipo == nome);
        }

        [Authorize(Roles = "Administrador")]
        // GET: Vinhos/Create
        public IActionResult InserirProdutor()
        {
            return View();
        }

        // POST: Vinhos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InserirProdutor([Bind("IdProdutor,NomeProdutor")] Produtor produtor)
        {
            if (ModelState.IsValid)
            {
                if (!ProdutorExists(produtor.NomeProdutor))
                {
                    _context.Produtor.Add(produtor);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(ListagemProdutores));
                }
            }
            return View(produtor);
        }

        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> ListagemProdutores()
        {
            return View(await _context.Produtor.ToListAsync());
        }

        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> ApagarProdutor(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtor = await _context.Produtor
                .FirstOrDefaultAsync(m => m.IdProdutor == id);
            if (produtor == null)
            {
                return NotFound();
            }

            return View(produtor);
        }

        // POST: Produtors/Delete/5
        [HttpPost, ActionName("ApagarProdutor")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ApagarProdutorConfirmed(int id)
        {
            var produtor = await _context.Produtor.FindAsync(id);
            _context.Produtor.Remove(produtor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListagemProdutores));
        }

        [Authorize(Roles = "Administrador")]
        // GET: Vinhos/Create
        public IActionResult InserirRegiao()
        {
            return View();
        }

        // POST: Vinhos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InserirRegiao([Bind("IdRegiao,NomeRegiao")] Regiao regiao)
        {
            if (ModelState.IsValid)
            {
                if (!RegiaoExists(regiao.NomeRegiao))
                {
                    _context.Regiao.Add(regiao);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(ListagemRegioes));
                }
            }
            return View(regiao);
        }

        [Authorize(Roles ="Administrador")]
        public async Task<IActionResult> ListagemRegioes()
        {
            return View(await _context.Regiao.ToListAsync());
        }

        [Authorize(Roles ="Administrador")]
        public async Task<IActionResult> ApagarRegiao(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regiao = await _context.Regiao
                .FirstOrDefaultAsync(r=>r.IdRegiao == id);
            if (regiao == null)
            {
                return NotFound();
            }

            return View(regiao);
        }

        // POST: Produtors/Delete/5
        [HttpPost, ActionName("ApagarRegiao")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ApagarRegiaoConfirmed(int id)
        {
            var regiao = await _context.Regiao.FindAsync(id);
            _context.Regiao.Remove(regiao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListagemRegioes));
        }

        [Authorize(Roles = "Administrador")]
        // GET: Vinhos/Create
        public IActionResult InserirTipo()
        {
            return View();
        }

        // POST: Vinhos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InserirTipo([Bind("IdTipo,NomeTipo")] Tipo tipo)
        {
            if (ModelState.IsValid)
            {
                if (!TipoExists(tipo.NomeTipo))
                {
                    _context.Tipo.Add(tipo);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(ListagemTipos));
                }
            }
            return View(tipo);
        }

        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> ListagemTipos()
        {
            return View(await _context.Tipo.ToListAsync());
        }

        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> ApagarTipo(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipo = await _context.Tipo
                .FirstOrDefaultAsync(r => r.IdTipo == id);
            if (tipo == null)
            {
                return NotFound();
            }

            return View(tipo);
        }

        // POST: Produtors/Delete/5
        [HttpPost, ActionName("ApagarTipo")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ApagarTipoConfirmed(int id)
        {
            var tipo = await _context.Tipo.FindAsync(id);
            _context.Tipo.Remove(tipo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListagemTipos));
        }
    }
}
