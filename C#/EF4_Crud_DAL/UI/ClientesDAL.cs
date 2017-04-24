using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DAL
{
    public class ClientesDAL : IAcessoDB<Cliente>
    {
        private CadastroEntities cadastroEntities;

        /// <summary>
        /// Saveregistro - Salva um registro
        /// </summary>
        /// <param name="registro"></param>
        /// <returns></returns>
        public int SaveRegistro(Cliente registro)
        {
            using (cadastroEntities = new CadastroEntities())
            {
                cadastroEntities.AddToClientes(registro);
                cadastroEntities.SaveChanges();
            }
            return registro.id;
        }

        /// <summary>
        /// Updateregistro - Atualiza um registro pelo id
        /// </summary>
        /// <param name="registro"></param>
        /// <returns></returns>
        public bool UpdateRegistro(Cliente registro)
        {
            EntityKey key;
            object originalItem;

            using (cadastroEntities = new CadastroEntities())
            {
                key = cadastroEntities.CreateEntityKey("Clientes", registro);

                if (cadastroEntities.TryGetObjectByKey(key, out originalItem))
                {
                    cadastroEntities.ApplyCurrentValues(key.EntitySetName, registro);
                }
                cadastroEntities.SaveChanges();
                return true;
            }
        }

        /// <summary>
        /// Getregistro - Obtem uma lista de clientes de acordo com o criterio de filtro
        /// </summary>
        /// <param name="registro"></param>
        /// <returns></returns>
        public List<Cliente> GetRegistro(Cliente registro)
        {
            cadastroEntities = new CadastroEntities();

            IQueryable<Cliente> consultaCliente = cadastroEntities.Clientes.AsQueryable<Cliente>();

            if (registro.id > 0)
            {
                consultaCliente = consultaCliente.Where(c => c.id == registro.id);
            }
            if (!string.IsNullOrEmpty(registro.nome))
            {
                consultaCliente = consultaCliente.Where(c => c.nome.Contains(registro.nome));
            }
            if (!string.IsNullOrEmpty(registro.email))
            {
                consultaCliente = consultaCliente.Where(c => c.email.Contains(registro.email));
            }
            if (!string.IsNullOrEmpty(registro.cidade))
            {
                consultaCliente = consultaCliente.Where(c => c.cidade.Contains(registro.cidade));
            }
            return consultaCliente.ToList();
        }

        /// <summary>
        /// GetRegistroPorCodigo
        /// </summary>
        /// <param name="registro"></param>
        /// <returns></returns>
        public Cliente GetRegistroPorCodigo(int codigo)
        {
            cadastroEntities = new CadastroEntities();
            Cliente cliente = cadastroEntities.Clientes.First(c => c.id == codigo);
            return cliente;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="registro"></param>
        /// <returns></returns>
        public List<Cliente> GetAll()
        {
            cadastroEntities = new CadastroEntities();

            IQueryable<Cliente> consultaCliente = cadastroEntities.Clientes.AsQueryable<Cliente>();
            return consultaCliente.ToList();
        }

        /// <summary>
        /// DeleteRecord - exclui um registro pelo id informado
        /// </summary>
        /// <param name="registro"></param>
        /// <returns></returns>
        public bool DeleteRegistro(Cliente registro)
        {

            using (cadastroEntities = new CadastroEntities())
            {
                var cli = cadastroEntities.Clientes.FirstOrDefault(c => c.id == registro.id);
                cadastroEntities.DeleteObject(cli);
                cadastroEntities.SaveChanges();
                return true;
            }
        }
    }
}
