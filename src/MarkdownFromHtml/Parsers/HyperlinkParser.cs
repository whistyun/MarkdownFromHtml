﻿using MarkdownFromHtml.MdElements;
using MarkdownFromHtml.MdElements.Inlines;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarkdownFromHtml.Parsers
{
    public class HyperlinkParser : ISimpleTagParser, IRequestEscapeString
    {
        public IEnumerable<string> SupportTag => new[] { "a" };

        public IEnumerable<string> EscapeStringTarget => new string[] { "](" };

        public bool TryReplace(HtmlNode node, ReplaceManager manager, out IEnumerable<IMdElement> generated)
        {
            var link = node.Attributes["href"]?.Value;
            var content = manager.ParseJagging(node.ChildNodes);
            var title = node.Attributes["title"]?.Value;
            if (link is null || !content.All(nd => nd is IMdInline))
            {
                generated = Array.Empty<IMdElement>();
                return false;
            }

            generated = new[] { new Hyperlink(content.Cast<IMdInline>(), link, title) };
            return true;
        }
    }
}
