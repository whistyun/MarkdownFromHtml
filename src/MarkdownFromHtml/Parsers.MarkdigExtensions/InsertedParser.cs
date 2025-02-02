﻿using MarkdownFromHtml.MdElements;
using MarkdownFromHtml.MdElements.Inlines;
using HtmlAgilityPack;
using System.Collections.Generic;

namespace MarkdownFromHtml.Parsers.MarkdigExtensions
{
    public class InsertedParser : SimpleInlineParser, IRequestEscapeString
    {
        public InsertedParser() : base("ins") { }

        public IEnumerable<string> EscapeStringTarget => new[] { "++" };

        public override bool TryReplace(HtmlNode node, ReplaceManager manager, out IEnumerable<IMdElement> generated)
            => Parse(node, manager, nds => new Inserted(nds), out generated);
    }
}
