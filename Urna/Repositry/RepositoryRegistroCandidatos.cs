using Newtonsoft.Json;
using NuGet.Protocol.Plugins;
using System.Text;
using Urna.interfaces;
using Urna.Models;

namespace Urna.Repositry
{
    public class RepositoryRegistroCandidatos : IRegistroCandidatos
    {
        private readonly string uprApi="https://localhost:7064/api/RegistroCandidatos";
        public RegistroCandidatos Create(RegistroCandidatos registroCandidatos)
        {
            var registroCandidatoCriado = new RegistroCandidatos();
            try
            {
                using (var cliente = new HttpClient())
                {
                    string jsonObjeto = JsonConvert.SerializeObject(registroCandidatos);
                    var content = new StringContent(jsonObjeto, Encoding.UTF8,"application/json");
                    var resposta = cliente.PostAsync(uprApi+ "PostRegistroCandidato", content);
                    resposta.Wait();
                    if (resposta.Result.IsSuccessStatusCode)
                    {
                        var retorno = resposta.Result.Content.ReadAsStringAsync();
                        registroCandidatoCriado = JsonConvert.DeserializeObject<RegistroCandidatos>(retorno.Result);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return registroCandidatoCriado;

        }

        public RegistroCandidatos Delete(Guid id)
        {
            var registroCandidatoCriado = new RegistroCandidatos();
            registroCandidatoCriado.Id = id;
            try
            {
                using (var cliente = new HttpClient())
                {
                    string jsonObjeto = JsonConvert.SerializeObject(registroCandidatoCriado);
                    var content = new StringContent(jsonObjeto, Encoding.UTF8, "application/json");
                    var resposta = cliente.PostAsync(uprApi + "DeleteRegistroCandidato", content);
                    resposta.Wait();
                    if (resposta.Result.IsSuccessStatusCode)
                    {
                        var retorno = resposta.Result.Content.ReadAsStringAsync();
                        registroCandidatoCriado = JsonConvert.DeserializeObject<RegistroCandidatos>(retorno.Result);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return registroCandidatoCriado;
        }

        
        public RegistroCandidatos GetOne(Guid id)
        {
            var registroCandidatoCriado = new RegistroCandidatos();
            registroCandidatoCriado.Id = id;
            try
            {
                using (var cliente = new HttpClient())
                {
                    string jsonObjeto = JsonConvert.SerializeObject(registroCandidatoCriado);
                    var content = new StringContent(jsonObjeto, Encoding.UTF8, "application/json");
                    var resposta = cliente.PostAsync(uprApi + "GetRegistroCandidato", content);
                    resposta.Wait();
                    if (resposta.Result.IsSuccessStatusCode)
                    {
                        var retorno = resposta.Result.Content.ReadAsStringAsync();
                        registroCandidatoCriado = JsonConvert.DeserializeObject<RegistroCandidatos>(retorno.Result);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return registroCandidatoCriado;
        }

        public List<RegistroCandidatos> List()
        {
            var retorno = new List<RegistroCandidatos>();
           
            try
            {
                using (var cliente = new HttpClient())
                {
                    var resposta = cliente.GetStringAsync(uprApi);
                    resposta.Wait();
                    retorno = JsonConvert.DeserializeObject<RegistroCandidatos[]>(resposta.Result).ToList();
                    
                }
            }
            catch
            {
                throw;
            }
            return retorno;
        }

        public RegistroCandidatos Update(RegistroCandidatos registroCandidatos)
        {
            var registroCandidatoCriado = new RegistroCandidatos();
            try
            {
                using (var cliente = new HttpClient())
                {
                    string jsonObjeto = JsonConvert.SerializeObject(registroCandidatos);
                    var content = new StringContent(jsonObjeto, Encoding.UTF8, "application/json");
                    var resposta = cliente.PostAsync(uprApi + "PutRegistroCandidato", content);
                    resposta.Wait();
                    if (resposta.Result.IsSuccessStatusCode)
                    {
                        var retorno = resposta.Result.Content.ReadAsStringAsync();
                        registroCandidatoCriado = JsonConvert.DeserializeObject<RegistroCandidatos>(retorno.Result);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return registroCandidatoCriado;

        }
    }
    /*
    public RegistroCandidatos getBylegend(int di1, int di2)
    {
        string distring1 = Convert.ToString(di1);
        string distring2 = Convert.ToString(di2);



    }*/

}
