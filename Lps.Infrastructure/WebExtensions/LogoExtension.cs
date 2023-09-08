﻿using Lps.Infrastructure.Helper;
using JinianNet.JNTemplate;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Lps.Infrastructure
{
    public static class LogoExtension
    {
        public static void AddLogo(this IServiceCollection services)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            var contentTpl = JnHelper.ReadTemplate("", "logo.txt");
            var content = contentTpl?.Render();

            Console.WriteLine(content);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Today's date: {0:D}", DateTime.Now);
            Console.WriteLine("Source: https://github.com/Lean365/LaplaceNet");
            Console.WriteLine("Docs：https://laplacenet.github.io/");
            Console.WriteLine("Donate：https://laplacenet.github.io/docs/others/donate.html");
        }
    }
}
