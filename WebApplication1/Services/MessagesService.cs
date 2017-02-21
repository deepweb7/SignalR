using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Services
{
    public partial class MessagesService
    {
        private GenericRepository<Messages> CustRepository;

        //CustomerRepository CustRepository;
        public MessagesService()
        {
            this.CustRepository = new GenericRepository<Messages>(new CRUD_SampleEntities());
        }

        public IEnumerable<Messages> GetAll(object[] parameters)
        {
            string spQuery = "[Get_Messages] {0}";
            return CustRepository.ExecuteQuery(spQuery, parameters);
        }

        public Messages GetbyID(object[] parameters)
        {
            string spQuery = "[Get_MessagesbyID] {0}";
            return CustRepository.ExecuteQuerySingle(spQuery, parameters);
        }

        public int Insert(object[] parameters)
        {
            string spQuery = "[Set_Messages] {0}, {1}, {2}";
            return CustRepository.ExecuteCommand(spQuery, parameters);
        }

        public int Update(object[] parameters)
        {
            string spQuery = "[Update_Messages] {0}, {1}, {2},{3}";
            return CustRepository.ExecuteCommand(spQuery, parameters);
        }

        public int Delete(object[] parameters)
        {
            string spQuery = "[Delete_Messages] {0}";
            return CustRepository.ExecuteCommand(spQuery, parameters);
        }
    }
}