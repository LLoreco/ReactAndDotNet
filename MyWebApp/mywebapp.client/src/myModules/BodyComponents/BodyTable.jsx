import { useEffect, useState } from 'react';
import ActionButtons from './ActionButtons';
import '../../myStyles/BodyComponents/BodyTable.css';

function BodyTable() {
    const [tasks, setTasks] = useState([]);
    const requestOptions = {
        method: "GET",
        redirect: "follow"
      };
      useEffect(() => {
        fetch("http://localhost:5016/api/Tasks/GetAllTasks", requestOptions)
            .then((response) => response.json())
            .then((result) => {
                console.log(result);
                setTasks(result);
            })
            .catch((error) => console.error(error));
    }, []);
    

    return (
        <div className="TableWrapper">
            <table className="TaskTable">
                <thead className="TaskTableThead">
                    <tr>
                        <th>ID</th>
                        <th>Название задачи</th>
                        <th>Время</th>
                        <th>Действия</th>
                    </tr>
                </thead>
                <tbody className="TaskTableBody">
                    {tasks.length > 0 ? (
                        tasks.map((task) => (
                            <tr key={task.id}>
                                <td>{task.Id}</td>
                                <td>{task.TaskName}</td>
                                <td>{task.TaskTime}</td>
                                <td><ActionButtons /></td>
                            </tr>
                        ))
                    ) : (
                        <tr><td colSpan="4">Задачи не найдены</td></tr>
                    )}
                </tbody>
            </table>
        </div>
    );
    
}

export default BodyTable;
