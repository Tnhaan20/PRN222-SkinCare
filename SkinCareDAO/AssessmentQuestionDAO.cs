﻿using Microsoft.EntityFrameworkCore;
using SkinCareBussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkinCareDAO
{
    public class AssessmentQuestionDAO
    {
        private SkinCareDBContext _dbContext;
        private static AssessmentQuestionDAO instance;

        public AssessmentQuestionDAO()
        {
            _dbContext = new SkinCareDBContext();
        }

        public static AssessmentQuestionDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AssessmentQuestionDAO();
                }
                return instance;
            }
        }


        public AssessmentQuestion GetOne(string id)
        {
            return _dbContext.AssessmentQuestions
                .SingleOrDefault(a => a.Id.Equals(id));
        }

        public List<AssessmentQuestion> GetAllQuestions()
        {
            return _dbContext.AssessmentQuestions
                
                .ToList();
        }

        public void Add(AssessmentQuestion a)
        {
            AssessmentQuestion cur = GetOne(a.Id);
            if (cur != null)
            {
                throw new Exception();
            }
            _dbContext.AssessmentQuestions.Add(a);
            _dbContext.SaveChanges();
        }

        public void Update(AssessmentQuestion a)
        {
            AssessmentQuestion cur = GetOne(a.Id);
            if (cur == null)
            {
                throw new Exception();
            }
            _dbContext.Entry(cur).CurrentValues.SetValues(a);
            _dbContext.SaveChanges();
        }

        public void Delete(string id)
        {
            AssessmentQuestion cur = GetOne(id);
            if (cur != null)
            {
                _dbContext.AssessmentQuestions.Remove(cur);
                _dbContext.SaveChanges(); // Delete the object
            }
        }


        
    }
}
