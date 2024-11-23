namespace JobSite.Application.InterviewSchedule.Commands.ApproveInterviewSchedule;

public class ApproveInterviewScheduleValidator : AbstractValidator<ApproveInterviewScheduleCommand>
{
    public ApproveInterviewScheduleValidator()
    {
        RuleFor(v => v.id)
            .NotEmpty().WithMessage("Id is required.");
        RuleFor(v => v.method)
            .InclusiveBetween(0, 1).WithMessage("Method must be between 0 and 1 with 0 is completed and 1 is canceled.");
    }
}