using DSMVC.App_Start;
using DSMVC.Models;
using MarkLogic.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace DSMVC.Controllers
{
    public class ClientController : Controller
    {
        private MarklogicContext mlDbContext;
        public IList<Client> clientCollection;

        public ClientController()
        {
            mlDbContext = new MarklogicContext();
        }

        // GET: Clients
        public async Task<ActionResult> Index()
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    JArray clientsArrary = await mlDbContext.basicTestsClientService.GetAllClients();
                    Client c  ;
                    clientCollection = new List<Client>();
                    if (clientsArrary != null)
                    {
                        foreach (var item in clientsArrary)
                        {
                            c = new Client();
                            c.Id = item["id"].ToString();
                            c.FName = item["name"].ToString();
                            c.LName= item["lastName"].ToString();
                            c.Adresse = item["Adresse"].ToString();
                            c.Gender = item["Gender"].ToString();
                            clientCollection.Add(c);
                        }
                    }

                    return View(clientCollection);
                }

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View(e);
            }
        }

        // GET: Client/Details/5
        public async Task<ActionResult> Details(string id)
        {
            JObject experiencesArrary = await mlDbContext.basicTestsClientService.GetClientDetail(id);
            Client c= new Client();
          
            if (experiencesArrary != null)
            {
                
                    c = new Client();
                    c.Id = experiencesArrary["id"].ToString();
                    c.FName = experiencesArrary["name"].ToString();
                    c.LName = experiencesArrary["lastName"].ToString();
                    c.Adresse = experiencesArrary["Adresse"].ToString();
                    c.Gender = experiencesArrary["Gender"].ToString();

            }

            return View(c);
        }

        // GET: Client/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Client/Create
        [HttpPost]
        public async Task<ActionResult> Create(Client client)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {               
                      await mlDbContext.basicTestsClientService.InsertClient(client.FName,client.LName,client.Adresse,client.Gender);  
                }
           
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View(e);
            }
        }

        // GET: Client/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            JObject experiencesArrary = await mlDbContext.basicTestsClientService.GetClientDetail(id);
            Client c = new Client();
            if (experiencesArrary != null)
            {
                c.Id = experiencesArrary["id"].ToString();
                c.FName = experiencesArrary["name"].ToString();
                c.LName = experiencesArrary["lastName"].ToString();
                c.Adresse = experiencesArrary["Adresse"].ToString();
                c.Gender = experiencesArrary["Gender"].ToString();

            }

            return View(c);
           
        }

        // POST: Client/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                await mlDbContext.basicTestsClientService.UpdateClient(collection["Id"],collection["FName"], collection["LName"], collection["Adresse"], collection["Gender"]);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Client/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            await mlDbContext.basicTestsClientService.DeleteClient(id);

            return RedirectToAction("Index");
        }

        // POST: Client/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
