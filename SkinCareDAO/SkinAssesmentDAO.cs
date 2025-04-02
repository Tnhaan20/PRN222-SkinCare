﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkinCareBussinessObject;

namespace SkinCareDAO
{
    public class SkinAssesmentDAO
    {

        private SkinCareDBContext _dbContext;
        private static SkinAssesmentDAO instance;

        public SkinAssesmentDAO()
        {
            _dbContext = new SkinCareDBContext();
        }

        public static SkinAssesmentDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SkinAssesmentDAO();
                }
                return instance;
            }
        }


        public SkinAssessment GetOne(string id)
        {
            return _dbContext.SkinAssessments
                .SingleOrDefault(a => a.Id.Equals(id));
        }

        public List<SkinAssessment> GetAll()
        {
            return _dbContext.SkinAssessments
                
                .ToList();
        }

        public void Add(SkinAssessment a)
        {
            SkinAssessment cur = GetOne(a.Id);
            if (cur != null)
            {
                throw new Exception();
            }
            _dbContext.SkinAssessments.Add(a);
            _dbContext.SaveChanges();
        }

        public void Update(SkinAssessment a)
        {
            SkinAssessment cur = GetOne(a.Id);
            if (cur == null)
            {
                throw new Exception();
            }
            _dbContext.Entry(cur).CurrentValues.SetValues(a);
            _dbContext.SaveChanges();
        }

        public void Delete(string id)
        {
            SkinAssessment cur = GetOne(id);
            if (cur != null)
            {
                _dbContext.SkinAssessments.Remove(cur);
                _dbContext.SaveChanges(); // Delete the object
            }
        }

    }
}
