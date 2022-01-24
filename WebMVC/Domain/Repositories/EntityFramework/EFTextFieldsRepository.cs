using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMVC.Domain.Entities;
using WebMVC.Domain.Repositories.Abstract;

namespace WebMVC.Domain.Repositories.EntityFramework
{
    public class EFTextFieldsRepository : ITextFieldsRepository
    {
        private readonly AppDbContext _context;
        public EFTextFieldsRepository(AppDbContext context)
        {
            _context = context;
        }
        public void DeleteTextField(Guid id)
        {
            _context.TextFields.Remove(new TextField() { Id = id });
            _context.SaveChanges();
        }

        public TextField GetTextFieldByCodeWord(string codeWord)
        {
            return _context.TextFields.FirstOrDefault(x => x.CodeWord == codeWord);
        }

        public TextField GetTextFieldById(Guid id)
        {
            return _context.TextFields.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<TextField> GetTextFields()
        {
            return _context.TextFields;
        }

        public void SaveTextField(TextField entity)
        {
            if(entity.Id == default)
            {
                _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            }
            else
            {
                _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            _context.SaveChanges();
        }
    }
}
