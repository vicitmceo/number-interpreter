const convertTriplet = require('../extensions/convertTriplet');
const { thousandWord } = require('../extensions/pluralize');

function thousandsMiddleware(req, res, next) {
  const thousands = Math.floor(req.num / 1000);

  if (thousands > 0) {
    const thousandWords = convertTriplet(thousands, true);
    req.words.push(...thousandWords, thousandWord(thousands));
  }

  req.num = req.num % 1000;
  next();
}

module.exports = thousandsMiddleware;
