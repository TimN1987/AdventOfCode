import { Day1, Day2, Day3 } from "./days/index.js"

function runChallenge(title, challengeInstance, methodName) {
    const start = process.hrtime.bigint();

    challengeInstance[methodName]();
    
    const end = process.hrtime.bigint();
    const ms = Number(end - start) / 1_000_000;
    
    console.log(`${title} run time = ${ms.toFixed(4)} ms.`);
}

runChallenge("Day 1", new Day1(), "moveLift");
runChallenge("Day 2", new Day2(), "orderStock");
runChallenge("Day 3", new Day3(), "deliver");