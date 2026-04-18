class Day7:
    def __init__(self):
        with open('../../Data/2015/day7.txt') as f:
            self.data = f.readlines()
            self.wires = {}

    def run_circuit(self):
        temp = []
        while ('a' not in self.wires):
            pass

    def and_gate(self, a, b):
        return a & b
    
    def or_gate(self, a, b):
        return a | b
    
    def not_gate(self, a):
        return ~a
    
    def lshift_gate(self, a, shift):
        return a << shift
    
    def rshift_gate(self, a, shift):
        return a >> shift