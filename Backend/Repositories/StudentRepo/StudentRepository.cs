using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Backend.Exceptions;
using Backend.Models;

namespace Backend.Repositories.StudentRepo
{
    public class StudentRepository : IStudentRepository
    {

        private readonly ProjectAppContext _context;
        private readonly IMapper _mapper;

        public StudentRepository(ProjectAppContext _ctx, IMapper map)
        {
            _context = _ctx;
            _mapper = map;
        }
        
        public long AddStudentPayment(StudentPayment studentPayment)
        {

            _context.StudentPayment.Add(studentPayment);
            _context.SaveChanges();

            return studentPayment.ID;
        }

        public bool MarkStudentPaymentAsPaid(string stripePaymentId)
        {
            StudentPayment? studentPayment = _context.StudentPayment.Where(sp => sp.StripePaymentID == stripePaymentId).FirstOrDefault();

            if (studentPayment == null)
            {
                throw new NotFoundException("Student payment not found");
            }

            studentPayment.IsPaid = true;
            _context.SaveChanges();

            return true;
        }


        public Student GetStudentById(long studentId)
        {
            Student? student = _context.Student.Where(s => s.ID == studentId).FirstOrDefault();

            if (student == null)
            {
                throw new NotFoundException("Student not found");
            }

            return student;
        }
    }
}