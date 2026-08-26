const { unitsMasculine, teens, tens } = require('../extensions/dictionaries');

function tensUnitsMiddleware(req, res, next) {
  const rest = req.num;

  if (rest >= 10 && rest < 20) {
    req.words.push(teens[rest - 10]);
  } else {
    const t = Math.floor(rest / 10);
    const u = rest % 10;
    if (t > 0) req.words.push(tens[t]);
    if (u > 0) req.words.push(unitsMasculine[u]);
  }

  next();
}

module.exports = tensUnitsMiddleware;
