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
        static public Guitar AjouterGuitar (this GuitaresDatabaseEntities DB, Guitar guitar)
        {
            try
            {
                //guitar.GuitarTypeId = DB.GetGuitarTypeIdByName(guitar.)
                DB.Guitars.Add(guitar);
                DB.SaveChanges();
            } catch 
            {
                throw new Exception("Impossible d'ajouter l'item a la bd");
            }

            return guitar;
        }

        static public bool EnleverGuitar (this GuitaresDatabaseEntities DB, Guitar guitar)
        {
            Guitar search = DB.Guitars.Find(guitar.Id);
            
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

        static public bool EnleverGuitar(this GuitaresDatabaseEntities DB, int guitar)
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

        static public bool ModifierGuitar (this GuitaresDatabaseEntities DB, Guitar guitar)
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

        static public Seller AjouterSeller (this GuitaresDatabaseEntities DB, Seller seller) 
        {
            try
            {
                seller = DB.Sellers.Add(seller);
                DB.SaveChanges();
                return seller;
            }
            catch
            {
                return null;
            }
        }

        static public bool ModifierSeller(this GuitaresDatabaseEntities DB, Seller seller) 
        {
            DB.Entry(seller).State = EntityState.Modified;
            DB.SaveChanges();
            return true;
        }

        static public bool EnleverSeller(this GuitaresDatabaseEntities DB, Seller seller) 
        {
            Seller search = DB.Sellers.Find(seller.Id);

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

        static public bool EnleverSeller(this GuitaresDatabaseEntities DB, int id)
        {
            Seller search = DB.Sellers.Find(id);

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

        public static int GetConditionIdByName(this GuitaresDatabaseEntities DB, string name)
        {
            name = name.First().ToString().ToUpper() + name.Substring(1).ToLower();
            Condition condition = DB.Conditions.Where(c => c.Name == name).FirstOrDefault();
            if (condition == null)
            {
                condition = new Condition();
                condition.Name = name;
                condition = DB.Conditions.Add(condition);
                DB.SaveChanges();
            }
            return condition.Id;
        }

        public static int GetGuitarTypeIdByName(this GuitaresDatabaseEntities DB, string name)
        {
            name = name.First().ToString().ToUpper() + name.Substring(1).ToLower();
            GuitarType guitarType = DB.GuitarTypes.Where(c => c.Name == name).FirstOrDefault();
            if (guitarType == null)
            {
                guitarType = new GuitarType();
                guitarType.Name = name;
                guitarType = DB.GuitarTypes.Add(guitarType);
                DB.SaveChanges();
            }
            return guitarType.Id;
        }

        public static int GetSellerIdByName(this GuitaresDatabaseEntities DB, string name)
        {
            name = name.First().ToString().ToUpper() + name.Substring(1).ToLower();
            Seller seller = DB.Sellers.Where(c => c.Name == name).FirstOrDefault();
            if (seller == null)
            {
                seller = new Seller();
                seller.Name = name;
                seller = DB.Sellers.Add(seller);
                DB.SaveChanges();
            }
            return seller.Id;
        }
    }
    
}