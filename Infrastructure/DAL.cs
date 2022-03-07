using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

using TP01.Models;

namespace TP01.Infrastructure
{
    static class DAL
    {
        static Guitar AjouterGuitar (this GuitaresDatabaseEntities DB, Guitar guitar)
        {
            try
            {
                DB.Guitars.Add(guitar);
                DB.SaveChanges();
            } catch 
            {
                throw new Exception("Impossible d'ajouter l'item a la bd");
            }

            return guitar;
        }

        static bool EnleverGuitar (this GuitaresDatabaseEntities DB, Guitar guitar)
        {
            Guitar search = DB.Guitars.Find(guitar);
            
            if (search != null)
            {
                try
                {
                    DB.Guitars.Remove(search);
                    DB.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }

            return false;
        }

        static bool ModifierGuitar (this GuitaresDatabaseEntities DB, Guitar guitar)
        {
            try
            {
                DB.Entry(guitar).State = EntityState.Modified;
                DB.SaveChanges();
            } catch
            {
                return false;
            }

            return true;
        }

        static Seller AjouterSeller (this GuitaresDatabaseEntities DB, Seller seller) 
        {
            try
            {
                DB.Sellers.Add(seller);
                DB.SaveChanges();
                return seller;
            }
            catch
            {
                return null;
            }
        }

        static bool ModifierSeller(this GuitaresDatabaseEntities DB, Seller seller) 
        {
            try
            {
                DB.Entry(seller).State = EntityState.Modified;
                DB.SaveChanges();
            }
            catch
            {
                return false;
            }

            return true;
        }

        static bool EnleverSeller(this GuitaresDatabaseEntities DB, Seller seller) 
        {
            Seller search = DB.Sellers.Find(seller);

            if (search == null)
                return false;

            try
            {
                DB.Sellers.Remove(search);
                DB.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
    
}