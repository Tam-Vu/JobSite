namespace JobSite.Application.InterviewSchedule.Commands.CreateInterviewSchedule;

public class CreateInterviewScheduleValidator : AbstractValidator<CreateInterviewScheduleCommand>
{
    public CreateInterviewScheduleValidator()
    {
        RuleFor(v => v.jobApplicationId)
            .NotEmpty().WithMessage("JobApplicationId is required.");
    }
}