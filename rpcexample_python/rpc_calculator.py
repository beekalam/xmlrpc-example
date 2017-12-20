#!/usr/bin/env python
# encoding: utf-8

from SimpleXMLRPCServer import SimpleXMLRPCServer
from xmlrpclib import Binary
import datetime
import sys


class CalculatorService:
    def add(self, a , b):
        return a + b

    def multiply(self, a, b):
        return a * b

    def subtract(self, a, b):
        return a - b

    def divide(self, a, b):
        raise RuntimeError("divide by zero")
        #fixme divide by zero
        if b == 0:
            return 0
        return a / b

    def raises_exception(self, msg):
        "Always raises a RuntimeError with the message passed in"
        raise RuntimeError(msg)


def make_server(server_address, port):
    server = SimpleXMLRPCServer((server_address, port),
                                logRequests=True,
                                allow_none=True)
    server.register_introspection_functions()
    server.register_multicall_functions()
    server.register_instance(CalculatorService())
    return server

def main(server_address, port):

    server = make_server("0.0.0.0", 9000)
    try:
        print 'Use Control-C to exit'
        server.serve_forever()
    except KeyboardInterrupt:
        print 'Exiting'

if __name__== "__main__":
    server = "localhost"
    port = 9000
    main(server, port)