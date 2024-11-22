namespace JobSite.Contracts.Application;

public record ApproveApplicationRequest
(
    int method
// 0 : Approve
// 1 : Reject
);