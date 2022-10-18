using System;
using System.Reflection;

namespace WebApi_Control_Vacunas_anti_Covid.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}