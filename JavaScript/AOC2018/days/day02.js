import fs from "fs"
import path from "path"

export default class Day2 {
    constructor() {
        const filePath = path.resolve("../../Data/2018/day2.txt");
        this.data = fs.readFileSync(filePath, "utf-8")
                    .split(/\r?\n/)
                    .filter(line => line.trim() != "")
                    .map(line => line.trim());
    }

    solve() {
        console.log("Day 2 solutions:");
        this.partOne();
        this.partTwo();
    }

    partOne() {
        let twoCount = 0, threeCount = 0;
        for (const s of this.data) {
            const [hasTwo, hasThree] = this.checkCharacters(s);
            twoCount += hasTwo ? 1 : 0;
            threeCount += hasThree ? 1 : 0;
        }
        console.log(`The checksum is ${twoCount * threeCount}`);
    }

    checkCharacters(s) {
        let letters = new Array(26).fill(0);
        for (const c of s) {
            letters[c.charCodeAt(0) - 97]++;
        }
        return [letters.includes(2), letters.includes(3)];
    }

    partTwo() {
        const length = this.data.length;
        for (let i = 0; i < length - 1; ++i) {
            for (let j = i + 1; j < length; ++j) {
                if (this.compare(this.data[i], this.data[j])) {
                    const letters = new Array(this.data[i].length - 1);
                    let idx = 0;
                    for (let k = 0; k < this.data[i].length; ++k) {
                        if (this.data[i][k] == this.data[j][k]) {
                            letters[idx] = this.data[i][k];
                            idx++;
                        }
                    }
                    console.log(`The common letters are: ${letters.join()}`);
                    return;
                }
            }
        }
    }
    
    compare(s, t) {
        let difference = false;
        for (let i = 0; i < s.length; ++i) {
            if (s[i] == t[i])
                continue;
            if (difference)
                return false;
            difference = true;
        }
        return difference;
    }
}