import React, { useState, useRef } from 'react';
import axios from 'axios';


export default function App() {
    const [results, setResults] = useState([]);
    const [query, setQuery] = useState(null);
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState(null);
    const searchInputRef = useRef();
    const dateTimeFormat = new Intl.DateTimeFormat('en', { year: 'numeric', month: 'short', day: '2-digit' });
    const personsUrl = "https://localhost:44383/persons";
    const getResults = async () => {
        if(query !== null && query !== undefined){
            setLoading(true);
        }
        try{
            const response = await axios.get(personsUrl);
            setResults(response.data);
        }catch(err){
            setError(err);
        }
        
        setLoading(false);
    };

    const addPerson = async () => {

        setLoading(true);
        try{
            await axios.post(personsUrl, {name: query});
        }catch(err){
            setError(err);
        }
        
        setLoading(false);
    };

    const handleAddPerson = event => {
        event.preventDefault();
        addPerson();
    };

    const handleSearch = () => {
        getResults();
    };

    const handleClearPerson = () => {
        setQuery("");
        searchInputRef.current.focus();
    };

    return (
        <div className="container max-w-md mx-auto p-4 m-2 bg-gray-200 shadow-lg rounded">
            <img src="https://icon.now.sh/people" alt="hacking" className="float-right h-12"></img>
            <h1 className="text-gray-600">Person Store</h1>
            <form onSubmit={handleAddPerson} className="mb-2">
                <input placeholder="name" ref={searchInputRef} type="text" onChange={event => setQuery(event.target.value)} value={query} className="border p-1 rounded"></input>
                <button  type="submit" className="bg-blue-300 rounded m-1 p-1">Add Person</button>
                <button type="button" onClick={handleClearPerson} className="bg-orange-300 text-white rounded m-1 p-1">Clear</button>
                <button type="button" onClick={handleSearch} className="bg-green-300 rounded m-1 p-1">List all people</button>
            </form>
            { loading ? (<div className="font-bold">Loading...</div>) : 
            <ul className="list-reset leading-normal">
                {results.map(result => (
                    <li key={result.id}>
                        <div className="text-blue-500 hover:text-blue-900">{result.name} {dateTimeFormat.format(new Date(result.createTime))}</div>
                    </li>
                ))}
            </ul>
            }
            {error && <div className="text-red-300 font-bold">{error.message}</div>}
        </div>
    );
}