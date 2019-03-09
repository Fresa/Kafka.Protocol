using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Kafka.Protocol.Generator.BackusNaurForm;

namespace Kafka.Protocol.Generator.Definitions.Parsers
{
    internal class MethodMetaDataParser
    {
        private readonly IBuffer<char> _buffer;
        private readonly Queue<Func<bool>> _handlers;

        private MethodMetaDataParser(IBuffer<char> buffer)
        {
            _buffer = buffer;
            _handlers = new Queue<Func<bool>>(new List<Func<bool>>
            {
                ParseName,
                ParseMethodType,
                ParseVersion
            });
            _handle = _handlers.Dequeue();
        }

        private string _name = "";
        private int _version;
        private MethodType _type;

        private string _tempBuffer = "";
        private Func<bool> _handle;

        internal static MethodMetaData Parse(Symbol symbol)
        {
            var buffer = new Buffer<char>(symbol.Name.ToCharArray());
            var methodSymbolParser = new MethodMetaDataParser(buffer);

            while (methodSymbolParser.Next()) { }

            return new MethodMetaData(
                methodSymbolParser._name,
                methodSymbolParser._version,
                methodSymbolParser._type);
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