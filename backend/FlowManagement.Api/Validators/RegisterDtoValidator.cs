using FluentValidation;
using FlowManagement.Api.DTOs.User;

namespace FlowManagement.Api.Validators
{
    public class RegisterDtoValidator : AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("用户名不能为空")
                .MinimumLength(3).WithMessage("用户名至少需要3个字符")
                .MaximumLength(50).WithMessage("用户名不能超过50个字符");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("密码不能为空")
                .MinimumLength(6).WithMessage("密码至少需要6个字符")
                .MaximumLength(100).WithMessage("密码不能超过100个字符");

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty().WithMessage("确认密码不能为空")
                .Equal(x => x.Password).WithMessage("两次输入的密码不一致");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("邮箱不能为空")
                .EmailAddress().WithMessage("邮箱格式不正确")
                .MaximumLength(100).WithMessage("邮箱不能超过100个字符");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("手机号不能为空")
                .Matches(@"^1[3-9]\d{9}$").WithMessage("手机号格式不正确");

            RuleFor(x => x.RealName)
                .NotEmpty().WithMessage("真实姓名不能为空")
                .MaximumLength(50).WithMessage("真实姓名不能超过50个字符");
        }
    }
}
