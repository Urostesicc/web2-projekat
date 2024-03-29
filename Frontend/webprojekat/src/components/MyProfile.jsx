import React, {useState} from "react"
import { Link } from "react-router-dom";
import {ToastContainer, toast} from 'react-toastify'; 
import 'react-toastify/dist/ReactToastify.css'; 
import { UpdateProfile} from "../services/UserService";

export const MyProfile = () => {
    const logedInUser = JSON.parse(localStorage.getItem("logedInUser"));
    const [username, setUsername] = useState(logedInUser.userName);
    const [email, setEmail] = useState(logedInUser.email);
    const [name, setName] = useState(logedInUser.name);
    const [lastname, setLastname] = useState(logedInUser.lastName);
    const [dateOfBirth, setDateOfBirth] = useState(logedInUser.dateOfBirth);
    const [adress, setAdress] = useState(logedInUser.adress);
    const [profilePicture, setProfilePicture] = useState(null);
    const [userType] = useState(logedInUser.userType);
    const [verifiedStatus] = useState(logedInUser.verified);

    const handleAlert = (message, type) => {
        if(type === "success")
            toast.success(message);
        else
            toast.error(message);
    }

    const handleSubmit = async (e) => {
        e.preventDefault();
        await UpdateProfile(username, name, lastname, email, dateOfBirth, adress, profilePicture, handleAlert);
        setUsername(logedInUser.userName);
        setEmail(logedInUser.email);
        setName(logedInUser.name);
        setLastname(logedInUser.lastName);
        setDateOfBirth(logedInUser.dateOfBirth);
        setAdress(logedInUser.adress);
        setProfilePicture(logedInUser.profilePicture); 
        window.location.reload();
    }


    return(
        <>
        <Link className='link-button' to='/dashboard'>
            <button className="back-to-dashboard-button">User menu</button>
        </Link> 
        {userType === "Seller" && <label className="verified-status">{verifiedStatus}</label>}
        <div className="my-profile-form-container">
            <ToastContainer/> 
            <form onSubmit={handleSubmit}>
                <table className="my-profile-table">
                    <tr>
                        <td>
                            <label className="my-profile-username-label"><h1>Welcome {username}</h1></label>
                        </td>
                        <td>
                            <div className="profile-picture-container">
                                <img className="profile-picture" src={logedInUser.profilePicture} alt="Profile"/>
                            </div>
                            <label htmlFor="profilePicture">Change profile picture:</label>
                            <input type="file" accept="image/*" onChange={(e) => setProfilePicture(e.target.files[0])} id="profilePicture" name="profilePicture" />
                
                        </td>
                    </tr>
                    <tr>
                        <td><label htmlFor="email">Your email:</label></td>
                        <td><input value={email} onChange={(e) => setEmail(e.target.value)} type="email" placeholder="youremail@gmail.com" id="email" name="email"/></td>
                    </tr>
                    <tr>
                        <td><label htmlFor="name">Your name:</label></td>
                        <td><input value={name} onChange={(e) => setName(e.target.value)} type="name" placeholder="name" /></td>
                    </tr>
                    <tr>
                        <td><label htmlFor="lastName">Your lastname:</label></td>
                        <td><input value={lastname} onChange={(e) => setLastname(e.target.value)} type="lastname" placeholder="lastname" /></td>
                    </tr>
                    <tr>
                        <td><label htmlFor="dateOfBirth">Your date of birth:</label></td>
                        <td><input type="datetime-local" value={dateOfBirth} onChange={(e) => setDateOfBirth(e.target.value)} id="dateOfBirth" name="dateOfBirth"></input></td>
                    </tr>
                    <tr>
                        <td><label htmlFor="adress">Your adress:</label></td>
                        <td><input value={adress} onChange={(e) => setAdress(e.target.value)} type="adress" placeholder="adress" /></td>
                    </tr>
                    <tr>
                        <td colSpan="2">
                            
                        </td>
                    </tr> 
                         
                </table>
                <button className="update-button" type="submit">Update profile</button>    
                </form> 
        </div>
        </>
    );
}