
namespace Backend.Dtos.StripeDtos
{
  public record AddStripePayment(
    string studentId,
    string courseId
  );
}