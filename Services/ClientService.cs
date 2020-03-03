using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using GymAPI.Models;
using GymAPI.Utils;

namespace GymAPI.Services
{
    public class ClientService
    {
        private readonly List<Client> _clients;
        DataUtils dataUtils = new DataUtils();

        public ClientService(){
            _clients = dataUtils.ReadClientJson();
        }

        public IEnumerable<Client> GetAll(){
            return _clients.OrderBy(x=>x.Id);
        }

        public Client GetClient(int id){
            return _clients.Where(x=>x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Client> CreateClient(Client client){
            _clients.Add(client);
            dataUtils.WriteClientJson(_clients);
            return _clients;
        }

        public IEnumerable<Client> UpdateClient(int id, Client client){
            _clients.Remove(_clients.Where(x=> x.Id == id).FirstOrDefault());
            client.Id = id;
            _clients.Add(client);
            List<Client> orderedList = new List<Client>(_clients.OrderBy(x=>x.Id));
            dataUtils.WriteClientJson(orderedList);
            return _clients;
        }

        public IEnumerable<Client> DeleteClient(int id){
            _clients.Remove(_clients.Where(x=> x.Id == id).FirstOrDefault());
            dataUtils.WriteClientJson(_clients);
            return _clients;
        }
    }

}