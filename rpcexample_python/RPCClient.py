from SimpleXMLRPCServer import SimpleXMLRPCServer
import xmlrpclib


server = xmlrpclib.ServerProxy('http://localhost:9000', allow_none=True)
print '1+2:', server.add(1,2)

