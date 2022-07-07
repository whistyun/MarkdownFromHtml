﻿using Html2Markdown.MdElements;
using Html2Markdown.MdElements.Inlines;
using HtmlAgilityPack;
using System.Collections.Generic;

namespace Html2Markdown.Parsers.MarkdigExtensions
{
    public class InsertedParser : SimpleInlineParser
    {
        public InsertedParser() : base("ins") { }

        public override bool TryReplace(HtmlNode node, ReplaceManager manager, out IEnumerable<IMdElement> generated)
            => Parse(node, manager, nds => new Inserted(nds), out generated);
    }
}
