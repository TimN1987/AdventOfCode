import fs, { rmSync } from "fs"
import path from "path"

export default class Day8 {
    constructor() {
        const filePath = path.resolve("../../Data/2025/day8.txt");
        const data = fs.readFileSync(filePath, "utf-8");
        this.lines = data
            .split('\n')
            .map(line => line.trim())
            .filter(line => line.length > 0)
            .map(line => line.split(',').map(Number));
        this.distances = this.findDistances();
    }

    printResults() {
        console.log("Day 8:");
        console.log(`Part 1: ${this.part1()}`);
        console.log(`Part 2: ${this.part2()}`);
    }

    part1() {
        const firstConnections = this.distances.slice(0, 1000);
        const circuits = this.createCircuits(firstConnections).map(circuit => circuit.length).sort((a,b) => b - a);
        return circuits[0] * circuits[1] * circuits[2];
    }

    part2() {
        const [start, end] = this.createOneCircuit(this.distances);
        const x1 = this.lines[start][0];
        const x2 = this.lines[end][0];
        return x1 * x2;
    }

    euclideanDistance(x1, y1, z1, x2, y2, z2) {
        return Math.sqrt((x1 - x2) ** 2 + (y1 - y2) ** 2 + (z1 - z2) ** 2);
    }

    findDistances() {
        const distances = [];
        const length = this.lines.length;
        for (let i = 0; i < length - 1; i++) {
            const x1 = this.lines[i][0];
            const y1 = this.lines[i][1];
            const z1 = this.lines[i][2];
            for (let j = i + 1; j < length; j++) {
                const x2 = this.lines[j][0];
                const y2 = this.lines[j][1];
                const z2 = this.lines[j][2];
                distances.push([this.euclideanDistance(x1, y1, z1, x2, y2, z2), i, j]);
            }
        }

        return distances.sort(function(a, b) { return a[0] - b[0] });
    }

    createCircuits(connections) {
        let circuits = [[connections[0][1], connections[0][2]]];
        for (let i = 1; i < connections.length; i++) {
            const start = connections[i][1];
            const end = connections[i][2];
            const notConnected = [];
            const connected = [[start, end]];
            for (const circuit of circuits) {
                if (circuit.includes(start) || circuit.includes(end)) {
                    connected.push(circuit);
                } else {
                    notConnected.push(circuit);
                }
            }
            const newCircuit = Array.from(new Set([start, end, ...connected.flat()]));
            notConnected.push(newCircuit);
            circuits = notConnected;
        }
        return circuits;
    }

    createOneCircuit(connections) {
        let circuits = [[connections[0][1], connections[0][2]]];
        for (let i = 1; i < connections.length; i++) {
            const start = connections[i][1];
            const end = connections[i][2];
            const notConnected = [];
            const connected = [[start, end]];
            for (const circuit of circuits) {
                if (circuit.includes(start) || circuit.includes(end)) {
                    connected.push(circuit);
                } else {
                    notConnected.push(circuit);
                }
            }
            const newCircuit = Array.from(new Set([start, end, ...connected.flat()]));
            notConnected.push(newCircuit);
            circuits = notConnected;
            if (circuits.length == 1 && circuits[0].length == 1000) {
                return [start, end];
            }
        }
        return [0, 0];
    }
}