using FluentValidation;
using ITB.Kusys.Cse.Project.Entities.Concrete;

namespace ITB.Kusys.Cse.Project.Bussiness.Validation
{
    public class StudentValidation : AbstractValidator<Student>
    {
        public StudentValidation()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("The First Name field is required.");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("The Last Name field is required.");
            RuleFor(x => x.BirthDate).NotEmpty().WithMessage("The Birthdate field is required.");
            RuleFor(x => x.BirthDate).LessThan(DateTime.Now.Date).GreaterThan(DateTime.Now.Date.AddYears(-100)).WithMessage("Birthdate is not valid");
            RuleFor(x => x.StudentCourse).NotEmpty().WithMessage("The Course field is required.");

        }

    }
}
