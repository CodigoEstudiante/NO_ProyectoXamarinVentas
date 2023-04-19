using AppNotas.Modelo;
using CarritoCompras.Modelo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CarritoCompras.Service
{
    public class ApiServiceFirebase
    {
        public static async Task<bool> RegistrarUsuario(Usuario oUsuario, ResponseAuthentication oResponse)
        {
            try
            {

                HttpClient client = new HttpClient();
                var body = JsonConvert.SerializeObject(oUsuario);
                var content = new StringContent(body, Encoding.UTF8, "application/json");
                var formatoapi = string.Concat(AppSettings.ApiFirebase, "{0}/{1}.json?auth={2}");

                var response = await client.PutAsync(
                    string.Format(formatoapi, "usuarios", oResponse.LocalId, oResponse.IdToken),
                    content);
                if (response.StatusCode.Equals(HttpStatusCode.OK))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                string t = ex.Message;
                return false;
            }

        }


        public static async Task<Dictionary<string, Categoria>> ObtenerCategorias()
        {
            Dictionary<string, Categoria> oObject = new Dictionary<string, Categoria>();
            try
            {
                HttpClient client = new HttpClient();
                string apiurlformat = string.Concat(AppSettings.ApiFirebase, "dbalmacen/categoria.json?auth={0}");
                var response = await client.GetAsync(string.Format(apiurlformat, AppSettings.oAuthentication.IdToken));
                if (response.StatusCode.Equals(HttpStatusCode.OK))
                {
                    var jsonstring = await response.Content.ReadAsStringAsync();

                    if (jsonstring != "null")
                    {
                        oObject = JsonConvert.DeserializeObject<Dictionary<string, Categoria>>(jsonstring);
                    }
                    return oObject;
                }
                else
                {
                    return oObject;
                }
            }
            catch (Exception ex)
            {
                string t = ex.Message;
                return oObject;
            }

        }

        public static async Task<Dictionary<string, Producto>> ObtenerProductos(string nombreCategoria)
        {
            Dictionary<string, Producto> oObject = new Dictionary<string, Producto>();
            try
            {
                HttpClient client = new HttpClient();
                string apiurlformat = string.Concat(AppSettings.ApiFirebase, "dbalmacen/categoria/{0}/productos.json?auth={1}");
                var response = await client.GetAsync(string.Format(apiurlformat, nombreCategoria, AppSettings.oAuthentication.IdToken));
                if (response.StatusCode.Equals(HttpStatusCode.OK))
                {
                    var jsonstring = await response.Content.ReadAsStringAsync();

                    if (jsonstring != "null")
                    {
                        oObject = JsonConvert.DeserializeObject<Dictionary<string, Producto>>(jsonstring);
                    }
                    return oObject;
                }
                else
                {
                    oObject = null;
                    return oObject;
                }
            }
            catch (Exception ex)
            {
                string t = ex.Message;
                oObject = null;
                return oObject;
            }

        }

        public static async Task<Usuario> ObtenerUsuario()
        {
            Usuario oObject = new Usuario();
            try
            {
                HttpClient client = new HttpClient();
                string apiformat = string.Concat(AppSettings.ApiFirebase, "usuarios/{0}.json?auth={1}");
                var response = await client.GetAsync(string.Format(apiformat, AppSettings.oAuthentication.LocalId, AppSettings.oAuthentication.IdToken));
                if (response.StatusCode.Equals(HttpStatusCode.OK))
                {
                    var jsonstring = await response.Content.ReadAsStringAsync();

                    if (jsonstring != "null")
                    {
                        oObject = JsonConvert.DeserializeObject<Usuario>(jsonstring);
                    }
                    return oObject;
                }
                else
                {
                    return oObject;
                }
            }
            catch (Exception ex)
            {
                string t = ex.Message;
                return oObject;
            }

        }

        public static async Task<bool> GuardarCambiosUsuario(Usuario oUsuario)
        {
            Usuario oObject = new Usuario();
            try
            {
                HttpClient client = new HttpClient();
                var body = JsonConvert.SerializeObject(oUsuario);
                var content = new StringContent(body, Encoding.UTF8, "application/json");


                string apiformat = string.Concat(AppSettings.ApiFirebase, "usuarios/{0}.json?auth={1}");
                var response = await client.PutAsync(string.Format(apiformat, AppSettings.oAuthentication.LocalId, AppSettings.oAuthentication.IdToken),content);
                if (response.StatusCode.Equals(HttpStatusCode.OK))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                string t = ex.Message;
                return false;
            }

        }

        public static async Task<bool> AgregarenBolsa(Bolsa oBolsa)
        {
            Usuario oObject = new Usuario();
            try
            {
                HttpClient client = new HttpClient();
                var body = JsonConvert.SerializeObject(oBolsa);
                var content = new StringContent(body, Encoding.UTF8, "application/json");


                string apiformat = string.Concat(AppSettings.ApiFirebase, "bolsa/{0}.json?auth={1}");
                var response = await client.PostAsync(string.Format(apiformat, AppSettings.oAuthentication.LocalId, AppSettings.oAuthentication.IdToken), content);
                if (response.StatusCode.Equals(HttpStatusCode.OK))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                string t = ex.Message;
                return false;
            }

        }

        public static async Task<bool> RetirardeBolsa(string IdBolsa)
        {
            Usuario oObject = new Usuario();
            try
            {
                HttpClient client = new HttpClient();
                string apiformat = string.Concat(AppSettings.ApiFirebase, "bolsa/{0}/{1}.json?auth={2}");
                var response = await client.DeleteAsync(string.Format(apiformat, AppSettings.oAuthentication.LocalId, IdBolsa, AppSettings.oAuthentication.IdToken));
                if (response.StatusCode.Equals(HttpStatusCode.OK))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                string t = ex.Message;
                return false;
            }
        }


        public static async Task<bool> EliminarBolsa()
        {
            Usuario oObject = new Usuario();
            try
            {
                HttpClient client = new HttpClient();
                string apiformat = string.Concat(AppSettings.ApiFirebase, "bolsa/{0}.json?auth={1}");
                var response = await client.DeleteAsync(string.Format(apiformat, AppSettings.oAuthentication.LocalId, AppSettings.oAuthentication.IdToken));
                if (response.StatusCode.Equals(HttpStatusCode.OK))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                string t = ex.Message;
                return false;
            }
        }


        public static async Task<Dictionary<string, Bolsa>> ObtenerBolsa()
        {
            Dictionary<string, Bolsa> oObject = new Dictionary<string, Bolsa>();
            try
            {
                HttpClient client = new HttpClient();
                string apiformat = string.Concat(AppSettings.ApiFirebase, "bolsa/{0}.json?auth={1}");
                var response = await client.GetAsync(string.Format(apiformat, AppSettings.oAuthentication.LocalId, AppSettings.oAuthentication.IdToken));
                if (response.StatusCode.Equals(HttpStatusCode.OK))
                {
                    var jsonstring = await response.Content.ReadAsStringAsync();

                    if (jsonstring != "null")
                    {
                        oObject = JsonConvert.DeserializeObject<Dictionary<string, Bolsa>>(jsonstring);
                    }
                    else
                        oObject = null;

                    return oObject;
                }
                else
                {
                    oObject = null;
                    return oObject;
                }
            }
            catch (Exception ex)
            {
                string t = ex.Message;
                oObject = null;
                return oObject;
            }

        }

        public static async Task<List<Departamento>> ObtenerDepartamentos()
        {
            Dictionary<string, Departamento> oObject = new Dictionary<string, Departamento>();
            List<Departamento> oListaDepartamento = new List<Departamento>();
            try
            {
                HttpClient client = new HttpClient();
                string apiformat = string.Concat(AppSettings.ApiFirebase, "ubigeo/departamento.json?auth={0}");
                var response = await client.GetAsync(string.Format(apiformat, AppSettings.oAuthentication.IdToken));
                if (response.StatusCode.Equals(HttpStatusCode.OK))
                {
                    var jsonstring = await response.Content.ReadAsStringAsync();

                    if (jsonstring != "null")
                    {
                        oObject = JsonConvert.DeserializeObject<Dictionary<string, Departamento>>(jsonstring);
                        foreach (KeyValuePair<string, Departamento> item in oObject)
                        {
                            oListaDepartamento.Add(new Departamento()
                            {
                                nombredepartamento = item.Value.nombredepartamento,
                            });
                        }
                    }

                    return oListaDepartamento;
                }
                else
                {
                    oListaDepartamento = null;
                    return oListaDepartamento;
                }
            }
            catch (Exception ex)
            {
                string t = ex.Message;
                oListaDepartamento = null;
                return oListaDepartamento;
            }
        }

        public static async Task<List<Provincia>> ObtenerProvincias(string p_nombredepartamento)
        {
            Dictionary<string, Provincia> oObject = new Dictionary<string, Provincia>();
            List<Provincia> oListaProvincia = new List<Provincia>();
            try
            {
                HttpClient client = new HttpClient();
                string apiformat = string.Concat(AppSettings.ApiFirebase, "ubigeo/provincia.json?auth={0}");
                var response = await client.GetAsync(string.Format(apiformat, AppSettings.oAuthentication.IdToken));
                if (response.StatusCode.Equals(HttpStatusCode.OK))
                {
                    var jsonstring = await response.Content.ReadAsStringAsync();

                    if (jsonstring != "null")
                    {
                        oObject = JsonConvert.DeserializeObject<Dictionary<string, Provincia>>(jsonstring);
                        foreach (KeyValuePair<string, Provincia> item in oObject)
                        {
                            if(item.Value.nombredepartamento == p_nombredepartamento)
                            {
                                oListaProvincia.Add(new Provincia()
                                {
                                    nombredepartamento = item.Value.nombredepartamento,
                                    nombreprovincia = item.Value.nombreprovincia
                                });
                            }
                            
                        }
                    }

                    return oListaProvincia;
                }
                else
                {
                    oListaProvincia = null;
                    return oListaProvincia;
                }
            }
            catch (Exception ex)
            {
                string t = ex.Message;
                oListaProvincia = null;
                return oListaProvincia;
            }
        }

        public static async Task<List<Distrito>> ObtenerDistrito(string p_nombreprovincia)
        {
            Dictionary<string, Distrito> oObject = new Dictionary<string, Distrito>();
            List<Distrito> oListaDistrito = new List<Distrito>();
            try
            {
                HttpClient client = new HttpClient();
                string apiformat = string.Concat(AppSettings.ApiFirebase, "ubigeo/distrito.json?auth={0}");
                var response = await client.GetAsync(string.Format(apiformat, AppSettings.oAuthentication.IdToken));
                if (response.StatusCode.Equals(HttpStatusCode.OK))
                {
                    var jsonstring = await response.Content.ReadAsStringAsync();

                    if (jsonstring != "null")
                    {
                        oObject = JsonConvert.DeserializeObject<Dictionary<string, Distrito>>(jsonstring);
                        foreach (KeyValuePair<string, Distrito> item in oObject)
                        {
                            if (item.Value.nombreprovincia == p_nombreprovincia)
                            {
                                oListaDistrito.Add(new Distrito()
                                {
                                    nombreprovincia = item.Value.nombreprovincia,
                                    nombredistrito = item.Value.nombredistrito
                                });
                            }

                        }
                    }

                    return oListaDistrito;
                }
                else
                {
                    oListaDistrito = null;
                    return oListaDistrito;
                }
            }
            catch (Exception ex)
            {
                string t = ex.Message;
                oListaDistrito = null;
                return oListaDistrito;
            }
        }


        public static async Task<List<Tienda>> ObtenerTiendas()
        {
            Dictionary<string, Tienda> oObject = new Dictionary<string, Tienda>();
            List<Tienda> oListaTienda = new List<Tienda>();
            try
            {
                HttpClient client = new HttpClient();
                string apiformat = string.Concat(AppSettings.ApiFirebase, "tiendas.json?auth={0}");
                var response = await client.GetAsync(string.Format(apiformat, AppSettings.oAuthentication.IdToken));
                if (response.StatusCode.Equals(HttpStatusCode.OK))
                {
                    var jsonstring = await response.Content.ReadAsStringAsync();

                    if (jsonstring != "null")
                    {
                        oObject = JsonConvert.DeserializeObject<Dictionary<string, Tienda>>(jsonstring);
                        foreach (KeyValuePair<string, Tienda> item in oObject)
                        {
                            oListaTienda.Add(new Tienda()
                            {
                                nombretienda = item.Value.nombretienda,
                                ubicacion = item.Value.ubicacion,
                                direccion1 = item.Value.direccion1,
                                direccion2 = item.Value.direccion2,
                                titulo = string.Format("{0} - {1}", item.Value.nombretienda, item.Value.ubicacion)
                            });
                        }
                    }

                    return oListaTienda;
                }
                else
                {
                    oListaTienda = null;
                    return oListaTienda;
                }
            }
            catch (Exception ex)
            {
                string t = ex.Message;
                oListaTienda = null;
                return oListaTienda;
            }
        }


        public static async Task<bool> RegistrarCompra(Compra oCompra)
        {
            try
            {
                
                HttpClient client = new HttpClient();
                var body = JsonConvert.SerializeObject(oCompra);
                var content = new StringContent(body, Encoding.UTF8, "application/json");
                var formatoapi = string.Concat(AppSettings.ApiFirebase, "{0}/{1}.json?auth={2}");

                var response = await client.PostAsync(string.Format(formatoapi, "compra", AppSettings.oAuthentication.LocalId, AppSettings.oAuthentication.IdToken), content);
                if (response.StatusCode.Equals(HttpStatusCode.OK))
                {
                    bool respuesta = await EliminarBolsa();
                    return respuesta;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                string t = ex.Message;
                return false;
            }

        }


        public static async Task<List<Compra>> ObtenerCompra()
        {
            Dictionary<string, Compra> oObject = new Dictionary<string, Compra>();
            List<Compra> oListaCompra = new List<Compra>();
            try
            {
                HttpClient client = new HttpClient();
                string apiformat = string.Concat(AppSettings.ApiFirebase, "compra/{0}.json?auth={1}");
                var response = await client.GetAsync(string.Format(apiformat,AppSettings.oAuthentication.LocalId, AppSettings.oAuthentication.IdToken));
                if (response.StatusCode.Equals(HttpStatusCode.OK))
                {
                    var jsonstring = await response.Content.ReadAsStringAsync();

                    if (jsonstring != "null")
                    {
                        oObject = JsonConvert.DeserializeObject<Dictionary<string, Compra>>(jsonstring);
                        foreach (KeyValuePair<string, Compra> item in oObject)
                        {
                            oListaCompra.Add(new Compra()
                            {
                                tipoEntrega = item.Value.tipoEntrega,
                                fechaCompra = item.Value.fechaCompra,
                                oDepacho = item.Value.oDepacho,
                                oDetallePago = item.Value.oDetallePago,
                                oListaBolsa = item.Value.oListaBolsa,
                                oTienda = item.Value.oTienda
                            });
                        }
                    }

                    return oListaCompra;
                }
                else
                {
                    oListaCompra = null;
                    return oListaCompra;
                }
            }
            catch (Exception ex)
            {
                string t = ex.Message;
                oListaCompra = null;
                return oListaCompra;
            }
        }


    }
}
