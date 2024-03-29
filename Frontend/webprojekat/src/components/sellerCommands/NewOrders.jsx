import { useEffect, useState } from "react"
import { useNavigate, Link } from "react-router-dom";
import { ToastContainer, toast } from "react-toastify";
import 'react-toastify/dist/ReactToastify.css';
import { CalculateCountdown, GetSellersNewOrders } from "../../services/OrderServices"; 


export const NewOrders = () => {
    const [myOrders, setMyOrders] = useState([]);
    const token = localStorage.getItem("token");
    const navigate = useNavigate();

    const handleAlert = (message, type) => {
        if(type === "success")
            toast.success(message);
        else
            toast.error(message);
    }

    const handleDetailedView = async(orderId) => {
        navigate("/order-details",{
            state:{
                pOrderId:orderId
            }
        })
    }


    useEffect( () => {
        const getOrders = async () => {
            try{
                const response = await GetSellersNewOrders(handleAlert, token);
                setMyOrders(response);
            }
            catch(ex){
                console.log(ex);
            }
        };
        getOrders();
    }, []);

    useEffect(() => {
        const interval = setInterval(() => {
          setMyOrders((prevOrders) => {
            return prevOrders.map((order) => {
              const updatedOrder = { ...order };
              if (!updatedOrder.initialDeliveryTime) { 
                updatedOrder.initialDeliveryTime = updatedOrder.deliveringTime;
              }
    
              updatedOrder.deliveringTime = CalculateCountdown(updatedOrder.initialDeliveryTime);
    
              return updatedOrder;
            });
          });
        }, 1000);
        return () => clearInterval(interval);
      }, []);

      return(
        <>
        <Link className='link-button' to='/dashboard'>
            <button className="back-to-dashboard-button">User menu</button>
        </Link> 
        <ToastContainer/>
        {myOrders.length === 0 ?
            <p style={{color:"white"}}>There is no any new orders at the moment.</p>
            :
            <table className="verify-sellers-table">
                <tr className="verify-sellers-table-header-row">
                    <th style={{display:"none"}}>Id</th>
                    <th>Number of products</th>
                    <th>Total price</th>
                    <th>Ordered At</th>
                    <th>Should be delivered in</th>
                    <th>Customer's comment</th>
                    <th>Details</th>
                </tr>
                {myOrders.map(order => (
                    <tr key={order.id}>
                        <td style={{display:"none"}}>{order.id}</td>
                        <td>{order.numberOfProducts}</td>
                        <td>{order.totalPrice}</td>
                        <td>{order.orderedAt}</td>
                        <td>{order.deliveringTime}</td>
                        <td>{order.comment}</td>
                        <td><button onClick={() => handleDetailedView(order.id)}>Details</button></td>
                    </tr>
                ))}
            </table>
        }
        </>
    )
}