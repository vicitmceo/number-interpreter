const { hundreds } = require('../extensions/dictionaries');

function hundredsMiddleware(req, res, next) {
  const h = Math.floor(req.num / 100);

  if (h > 0) {
    req.words.push(hundreds[h]);
  }

  req.num = req.num % 100;
  next();
}

module.exports = hundredsMiddleware;
