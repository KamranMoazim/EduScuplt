using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;

namespace Backend.Repositories.StudentRepo
{
    public interface IStudentRepository
    {
        
        long AddStudentPayment(StudentPayment studentPayment);
        bool MarkStudentPaymentAsPaid(string stripePaymentId);
    }
}