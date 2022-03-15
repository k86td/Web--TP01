﻿using System;
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
        static public Guitar AjouterGuitar(this GuitaresDatabaseEntities DB, Guitar guitar)
        {
            try
            {
                //guitar.GuitarTypeId = DB.GetGuitarTypeIdByName(guitar.)
                DB.Guitars.Add(guitar);
                DB.SaveChanges();
            }
            catch
            {
                throw new Exception("Impossible d'ajouter l'item a la bd");
            }

            return guitar;
        }

        static public bool EnleverGuitar(this GuitaresDatabaseEntities DB, Guitar guitar)
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

        static public bool ModifierGuitar(this GuitaresDatabaseEntities DB, Guitar guitar)
        {
            try
            {
                DB.Entry(guitar).State = EntityState.Modified;
                DB.SaveChanges();
            }
            catch
            {
                return false;
            }

            return true;
        }

        static public Seller AjouterSeller(this GuitaresDatabaseEntities DB, Seller seller)
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

        public static List<Guitar> FilteredGuitarList(this GuitaresDatabaseEntities DB, int soldFilterChoice, int sellerId)
        {
            IQueryable<Guitar> guitarsFound = null;
            if (sellerId != 0)
                guitarsFound = DB.Guitars.OrderByDescending(g => g.AddDate).Where(g => g.SellerId == sellerId);
            else
                guitarsFound = DB.Guitars.OrderByDescending(g => g.AddDate);
            switch (soldFilterChoice)
            {
                case 1: /* Not sold */
                    return guitarsFound.Where(g => !g.Sold).ToList();
                case 2: /* Sold */
                    return guitarsFound.Where(g => g.Sold).ToList();
                default: return guitarsFound.ToList();
            }
        }
    }
}