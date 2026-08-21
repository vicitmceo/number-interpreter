# Інтерпретатор чисел

Web-додаток на Express.js, побудований за принципом ланцюжка middleware-компонентів
(на основі підходу з [sunmeat/middlewares](https://github.com/sunmeat/middlewares)).

Перетворює число з діапазону **-100000 .. 100000** у текстовий опис українською мовою.
Для від'ємних чисел додається приставка **"мінус "**.

## Архітектура

Запит `GET /interpret?number=...` проходить через ланцюжок із 6 middleware:

1. `middlewares/parseNumberMiddleware.js` — зчитування та валідація числа з query-параметра
2. `middlewares/signMiddleware.js` — обробка знаку (додає "мінус")
3. `middlewares/thousandsMiddleware.js` — розряд тисяч (включно з рівно 100000)
4. `middlewares/hundredsMiddleware.js` — розряд сотень
5. `middlewares/tensUnitsMiddleware.js` — розряди десятків та одиниць
6. `middlewares/finalizeMiddleware.js` — формування та надсилання відповіді

Словники слів та допоміжні функції винесені окремо в `extensions/`:

- `extensions/dictionaries.js` — масиви слів (одиниці, десятки, сотні, числівники 10-19)
- `extensions/convertTriplet.js` — перетворення трицифрового числа у слова
- `extensions/pluralize.js` — узгодження слова "тисяча/тисячі/тисяч"

## Запуск

```bash
npm install
npm start
```

Відкрити в браузері: `http://localhost:3000`

## Приклади

- `GET /interpret?number=0` → `нуль`
- `GET /interpret?number=-4205` → `мінус чотири тисячі двісті п'ять`
- `GET /interpret?number=100000` → `сто тисяч`
- `GET /interpret?number=21` → `двадцять один`
