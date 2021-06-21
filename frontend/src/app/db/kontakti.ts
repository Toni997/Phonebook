const kontakti = [
  {
    ime: 'Marin',
    prezime: 'Ljubomir',
    nadimak: 'Mar',
    adresa: '',
    emailAdrese: [],
    brojeviTelefona: [
      {
        pozivniBrojDrzave: '321',
        broj: '21233',
        opis: 'Kućni',
        glavni: true,
      },
      {
        pozivniBrojDrzave: '432',
        broj: '24322423',
        opis: 'Drugi Mobitel',
        glavni: false,
      },
    ],
    tagovi: [{ naziv: 'Prika' }, { naziv: 'Kraljina' }],
    bookmarkiran: false,
  },
];

export default kontakti;

/* TESTNI JSON
  {
    "Ime": "gdfgdf",
    "Prezime": "Antić",
    "Nadimak": "Picula",
    "Adresa": "Narodnog Preporoda 41",
    "EmailAdrese": [
      { "Email": "toni.kazinoti@gmail.com", "Glavna": true },
      { "Email": "tonino@gmail.com", "Glavna": false }
    ],
    "BrojeviTelefona": [
      {
        "PozivniBrojDrzave": "543",
        "Broj": "6456464",
        "Opis": "Privatni",
        "Glavni": true
      },
      {
        "PozivniBrojDrzave": "385",
        "Broj": "565645",
        "Opis": "Poslovni",
        "Glavni": false
      }
    ],
    "Tagovi": [
      { "Tag": "Prijatelj" },
      { "Tag": "Kralj" }
    ],
    "Bookmarkiran": true
}
*/
