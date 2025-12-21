using BusinessLayer.Abstract;
using BusinessLayer.Validations;
using DataAccessLayer.Abstract;
using DataAccessLayer.Configuration;
using EntityLayer.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Net.Security;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concreate
{
    public class AdminManager : IAdminService
    {
        private readonly IAdminDal _adminDal;
        private readonly AdminValidation _validationRulesAdmin;
        public AdminManager(IAdminDal adminDal, AdminValidation validationRulesAdmin)
        {
            _adminDal = adminDal;
            _validationRulesAdmin = validationRulesAdmin;
        }
        public List<Admin> TGetAllList()
        {
            return _adminDal.GetAllList();
        }

        public Admin TGetByID(int id)
        {
            return _adminDal.GetByID(id);
        }

        public List<Admin> TGetListByFilter(Expression<Func<Admin, bool>> filter)
        {
            return _adminDal.GetListByFilter(filter);
        }

        public void TInsert(Admin entity)
        {
            var result = _validationRulesAdmin.Validate(entity);
            if (!result.IsValid) throw new ValidationException(result.Errors);
            List<string> hashPasswordandMail = HidePasswordandMail(entity.Password, entity.MailAddress);
            Admin admin = new Admin()
            {
                MailAddress = hashPasswordandMail[1].ToString(),
                Password = hashPasswordandMail[0].ToString(),
                NameSurname = entity.NameSurname,
                RoleID =entity.RoleID,
                Status=entity.Status
            };
            _adminDal.Insert(admin);
        }

        public void TUpdate(Admin entity)
        {
            var result = _validationRulesAdmin.Validate(entity);
            if (!result.IsValid) throw new ValidationException(result.Errors);
            List<string> hashPasswordandMail = HidePasswordandMail(entity.Password, entity.MailAddress);
            entity.Password = hashPasswordandMail[0].ToString();
            _adminDal.Update(entity);
        }

        public List<string> HidePasswordandMail(string password, string mail)
        {
            List<string> result = new List<string>();

            // 1️⃣ PASSWORD → HASH (SHA256)
            string hashedPassword = HashSHA256(password);
            result.Add(hashedPassword);

            // 2️⃣ MAIL → MASK
            string maskedMail = MaskEmail(mail);
            result.Add(maskedMail);

            return result;
        }

        private string HashSHA256(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = sha256.ComputeHash(bytes);

                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2"));
                }

                return sb.ToString();
            }
        }

        private string MaskEmail(string email)
        {
            if (string.IsNullOrEmpty(email) || !email.Contains("@"))
                return email;

            string[] parts = email.Split('@');
            string name = parts[0];
            string domain = parts[1];

            if (name.Length <= 2)
                return name[0] + "***@" + domain;

            string visible = name.Substring(0, 2);
            string masked = new string('*', name.Length - 2);

            return visible + masked + "@" + domain;
        }



    }
}
