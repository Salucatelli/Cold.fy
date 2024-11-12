import axios from 'axios';
var url;

function get(urli) {
    url = urli;
}
get();
var a;

axios.get("http://localhost:3000/music",
).then(response => {
    a = response.data;
}).catch(err => {
    console.log(err);
});

console.log(a)
