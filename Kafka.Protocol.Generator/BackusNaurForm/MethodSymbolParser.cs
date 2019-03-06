using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Kafka.Protocol.Generator.Extensions;

namespace Kafka.Protocol.Generator.BackusNaurForm
{
    internal class MethodSymbolParser
    {
        private readonly IBuffer<char> _buffer;
        private readonly Queue<Func<bool>> _handlers;

        private MethodSymbolParser(IBuffer<char> buffer)
        {
            _buffer = buffer;
            _handlers = new Queue<Func<bool>>(new List<Func<bool>>
            {
                ParseName,
                ParseMethodType,
                ParseVersion,
                ParseDefinedAs
            });
            _handle = _handlers.Dequeue();
        }

        private string _name = "";
        private int _version;
        private MethodType _type;

        private string _tempBuffer = "";
        private Func<bool> _handle;

        internal static MethodSymbol Parse(IBuffer<char> buffer)
        {
            var methodSymbolParser = new MethodSymbolParser(buffer);
            while (methodSymbolParser.Next()) { }

            return new MethodSymbol
            {
                Name = methodSymbolParser._name,
                Version = methodSymbolParser._version,
                Type = methodSymbolParser._type
            };
        }

        private bool ParseName()
        {
            if (_buffer.Current == ' ')
            {
                return false;
            }

            _name += _buffer.Current;
            return true;
        }

        private bool ParseMethodType()
        {
            if (_buffer.Current == ' ')
            {
                _type = (MethodType)Enum.Parse(typeof(MethodType), _tempBuffer);
                _tempBuffer = "";
                return false;
            }

            _tempBuffer += _buffer.Current;
            return true;
        }

        private bool ParseVersion()
        {
            if (_buffer.Current == ')')
            {
                _version = int.Parse(_tempBuffer.Split(' ')[1]);
                _tempBuffer = "";
                return false;
            }

            _tempBuffer += _buffer.Current;
            return true;
        }

        private bool ParseDefinedAs()
        {
            if (_buffer.CurrentSequenceIs("=>"))
            {
                _buffer.MoveForward(2);
                return false;
            }

            return true;
        }

        private bool Next()
        {
            if (_buffer.MoveToNext() == false)
            {
                throw new SyntaxErrorException("Reached end. Expected more characters");
            }

            var shouldHandleMore = _handle();

            if (shouldHandleMore)
            {
                return true;
            }

            if (_handlers.Any())
            {
                _handle = _handlers.Dequeue();
                return true;
            }

            return false;
        }
    }
}