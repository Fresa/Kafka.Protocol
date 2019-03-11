using System;
using System.Collections.Generic;
using System.Linq;
using Kafka.Protocol.Generator.BackusNaurForm;

namespace Kafka.Protocol.Generator.Definitions.Parsers
{
    internal class HeaderMetaDataParser
    {
        private readonly IBuffer<char> _buffer;
        private readonly Queue<Func<bool>> _handlers;

        private HeaderMetaDataParser(IBuffer<char> buffer)
        {
            _buffer = buffer;
            _handlers = new Queue<Func<bool>>(new List<Func<bool>>
            {
                ParseMethodType,
                ParseName
            });
            _handle = _handlers.Dequeue();
        }

        private string _name = "";
        private MethodType _type;

        private string _tempBuffer = "";
        private Func<bool> _handle;

        internal static HeaderMetaData Parse(Symbol symbol)
        {
            var buffer = new Buffer<char>(symbol.Name.ToCharArray());
            var methodSymbolParser = new HeaderMetaDataParser(buffer);

            while (methodSymbolParser.Next()) { }

            return new HeaderMetaData(
                methodSymbolParser._name,
                methodSymbolParser._type);
        }

        private bool ParseName()
        {
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

        private bool Next()
        {
            if (_buffer.MoveToNext() == false)
            {
                return false;
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