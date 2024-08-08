using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dar.Syntax
{
class P
{
    enum SyntaxKind 
{
    NumberToken, WhiteSpaceToken, PlusToken, MinusToken, StarToken, SlashToken, OpenParenthesisToken, 
    CloseParenthesisToken, BadToken, EndOfFileToken, NumberExpression, BinaryExpression, ParenthesizedExpression
}

}
}