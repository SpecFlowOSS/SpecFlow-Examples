using System;

namespace CommunityContentSubmissionPage.API.Specs.Steps
{
    public record TypenameEntry(string Typename);
    public record ExpectedSubmissionContentEntry(string? Type, string? Url, string? Email, string? Description);
    public record SubmissionEntryFormRowObject(string Label, string Value);
}