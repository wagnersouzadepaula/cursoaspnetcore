using System;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace DevIO.UI.Site.Extensions
{
    //qbab case se a tag se chamar <email-de-contato> ao definir a classe que herdará a taghelper usamos camelcase ficando "EmailDeContato", ou seja, substituímos os hífens pela letra maiúscula da próxima palavra.
     //nao havendo hifenização na taghelper, usa-se o nome da tag com a primeira letra maiúscula (uma vez que estamos criando uma classe na definição da taghelper.

    public class EmailTagHelper : TagHelper
	{
        public string EmailDomain { get; set; } = "hotmail.com";

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            var content = await output.GetChildContentAsync();
            var target = content.GetContent() + "@" + EmailDomain;
            output.Attributes.SetAttribute("href", "mailto:" + target);
            output.Content.SetContent(target);
        }
    }
}

