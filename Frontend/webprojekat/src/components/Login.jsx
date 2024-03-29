import React, {useEffect, useState} from "react";
import { Link, useNavigate } from "react-router-dom";
import { LogIn, FacebookLogIn } from "../services/UserService.js";
import {ToastContainer, toast} from 'react-toastify'; 
import 'react-toastify/dist/ReactToastify.css';
import FacebookLogin from "react-facebook-login";

export const Login = () => {
    const logedInUser = JSON.parse(localStorage.getItem("logedInUser"));
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');

    const navigate = useNavigate();

    const handleAlert = (message, type) => {
        if(type === "success")
            toast.success(message);
        else
            toast.error(message);
    }

    const handleLogin = async (e) => { 
        e.preventDefault(); 
        await LogIn(username, password, handleAlert, navigate);            
    }

    useEffect( () => {
        const logedInUser = localStorage.getItem("logedInUser");
        if(logedInUser)
            navigate("/my-profile");
    }, [navigate]);

    const responseFacebook = async (response) => {
        console.log("login result", response); 
        if(response.error != undefined)
            console.log("Error: ", response.error);
        else
        {
            console.log("Success");
            console.log(response.id); 
            await FacebookLogIn(response.name, response.id, response.picture.data.url, response.email, handleAlert, navigate);
        }
    }

    return(
        <>
        <h1 className="link-text">Welcome to our web shop</h1>
        <div className="auth-form-container">
            <div className="login-form-div">
                <div style={{width:"300px"}}>
                    <h2>Log in</h2>
                    <form className="login-form" onSubmit={handleLogin}>
                        <label htmlFor="username">username</label>
                        <input value={username} onChange={(e) => setUsername(e.target.value)} type="username" placeholder="yourusername" id="username" name="username"/> 
                        <label htmlFor="password">password</label>
                        <input value={password} onChange={(e) => setPassword(e.target.value)} type="password" placeholder="password" id="password" name="password"/> 
                        <button type="submit">Log in</button>
                    </form>
                    <button className="link-button">
                        <Link className="link-text" to='/register'>
                            Register here 
                        </Link>
                    </button>
                </div>
                <div className="login-with-facebook-div">
                    <h2>Or you can continue with facebook</h2>
                    <FacebookLogin
                        appId="661808275998409"
                        autoLoad={true}
                        fields="name,email,picture"
                        returnScopes={true} 
                        callback={responseFacebook} />
                    <ToastContainer />
                </div>
            </div>
        </div>
        </>
    )
}