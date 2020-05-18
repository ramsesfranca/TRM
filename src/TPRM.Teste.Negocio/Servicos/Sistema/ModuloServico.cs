using System.Collections.Generic;
using System.Linq;
using TPRM.SAP.Modelo.Entidades.Sistema;
using TPRM.SAP.Modelo.Enums;
using TPRM.SAP.Modelo.Interfaces.Repositorios.Sistema;
using TPRM.SAP.Modelo.Interfaces.Servicos.Sistema;

namespace TPRM.SAP.Negocio.Servicos.Sistema
{
    public class ModuloServico : ServicoBase<Modulo, int, IModuloRepositorio>, IModuloServico
    {
        public List<Modulo> SelecionarTodosModulosAtivos()
        {
            return this.RepositorioBase.SelecionarPor(x => x.Status == Status.Ativo, new string[] { "Funcionalidades.Acoes" })
                .AsEnumerable()
                .OrderBy(x =>
                {
                    x.Funcionalidades = x.Funcionalidades.Where(f => f.Status == Status.Ativo).AsEnumerable()
                    .Select(f => new Funcionalidade()
                    {
                        Id = f.Id,
                        Nome = f.Nome,
                        Texto = f.Texto,
                        Acao = f.Acao,
                        Controlador = f.Controlador,
                        Status = f.Status,
                        ModuloId = f.ModuloId,
                        Modulo = f.Modulo,
                        Acoes = f.Acoes.Where(a => !a.Nome.Contains("Listar")).ToList(),
                        Permissoes = f.Permissoes
                    }).OrderBy(y => y.Ordem).ToList(); return x.Ordem;
                }).ToList();
        }

        public List<Modulo> SelecionarTodosPorPerfil(int perfilId)
        {
            return this.RepositorioBase.SelecionarPor(x => x.Status == Status.Ativo)
                .SelectMany(x => x.Funcionalidades.Where(f => f.Acao != null && f.Status == Status.Ativo && f.Permissoes.Any(p => p.PerfilId == perfilId)))
                .GroupBy(x => x.Modulo).AsEnumerable()
                .Select(x => new Modulo
                {
                    Id = x.Key.Id,
                    Nome = x.Key.Nome,
                    Area = x.Key.Area,
                    Ordem = x.Key.Ordem,
                    Status = x.Key.Status,
                    Funcionalidades = x.Key.Funcionalidades.OrderBy(f => f.Ordem).ToList()
                }).OrderBy(x => x.Ordem).ToList();
        }
    }
}
