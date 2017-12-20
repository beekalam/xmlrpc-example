from Tkinter import *
import xmlrpclib
import rpc_calculator


class CalcServer:
    def __init__(self, server_address ="localhost", port ="9000"):
        self.server_address = server_address
        self.port = port
        self.server=None
        try:
            self.server = rpc_calculator.make_server( self.server_address, int(self.port))
            try:
                print 'Use Control-C to exit'
                self.server.serve_forever()
            except KeyboardInterrupt:
                print 'Exiting'
        except:
            print "could not connect to server"



    def change_address(self, server_address):
        self.server = None
        # try:
            # self.server = rpc_calculator.make_server(sel)

if __name__ =="__main__":
    calc_server = CalcServer()
    root = Tk()
    calc = Frame(root)
    calc.grid()

    root.title("Calculator")
    server_address = Entry(calc)
    server_address.grid(row = 0, column = 0, pady=10,padx=10,sticky='W')
    server_address.insert(0, "localhost")

    server_port =  Entry(calc)
    server_port =  Entry(calc)
    server_port.grid(row = 1, column = 0,sticky='WN',pady=10, padx=10)
    server_port.insert(0, "9000")

    change_server_btn = Button(text='change server address')
    change_server_btn.grid(row = 1, column = 0)
    change_server_btn["command"] = lambda:calc.change_server(server_address.get())

    server_output = Text(calc)
    server_output.grid(row = 2, pady = 5, column=0)



    root.mainloop()

