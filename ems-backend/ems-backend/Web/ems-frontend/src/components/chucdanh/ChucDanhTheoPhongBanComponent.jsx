import { getChucDanhTheoPhongBan } from '@/services/ChucDanhTheoPhongBanService';
import React, { useEffect, useState } from 'react';

const ChucDanhPhongBanComponent = () => {
    const [chucDanhPhongBans, setChucDanhPhongBans] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    useEffect(() => {
        const fetchChucDanhPhongBan = async () => {
            try {
                const data = await getChucDanhTheoPhongBan();
                setChucDanhPhongBans(data);
            } catch (error) {
                console.error('Error loading data:', error);
                setError('Không thể tải dữ liệu');
            } finally {
                setLoading(false);
            }
        };

        fetchChucDanhPhongBan();
    }, []);

    if (loading) return <div>Loading...</div>;
    if (error) return <div>{error}</div>;

    // Tính toán rowspan cho tenPhongBan
    const rowspanMap = chucDanhPhongBans.reduce((acc, curr) => {
        acc[curr.tenPhongBan] = (acc[curr.tenPhongBan] || 0) + 1;
        return acc;
    }, {});

    let previousPhongBan = null;

    return (
        <div className="container  mx-auto mt-8 min-h-screen">
            <h2 className="ml-96 text-3xl mb-4">Chức Danh Theo Phòng Ban</h2>
            <div className="overflow-x-auto">
                <table className="ml-80 w-1/2 bg-white border-2 border-gray-200">
                    <thead>
                        <tr>
                            <th className="px-6 py-3 border-b-2 border-gray-200 bg-gray-100 text-left text-xs font-semibold text-gray-600 uppercase tracking-wider">Phòng Ban</th>
                            <th className="px-6 py-3 border-b-2 border-gray-200 bg-gray-100 text-left text-xs font-semibold text-gray-600 uppercase tracking-wider">Chức Danh</th>
                        </tr>
                    </thead>
                    <tbody>
                        {chucDanhPhongBans.map((cdpb, index) => {
                            const isFirstOccurrence = previousPhongBan !== cdpb.tenPhongBan;
                            previousPhongBan = cdpb.tenPhongBan;

                            return (
                                <tr key={index}>
                                    {isFirstOccurrence && (
                                        <td
                                            className="px-6 py-4 border-b border-gray-200 bg-white text-sm"
                                            rowSpan={rowspanMap[cdpb.tenPhongBan]}
                                        >
                                            {cdpb.tenPhongBan}
                                        </td>
                                    )}
                                    <td className="px-6 py-4 border-b border-gray-200 bg-white text-sm">
                                        {cdpb.tenChucDanh}
                                    </td>
                                </tr>
                            );
                        })}
                    </tbody>
                </table>
            </div>
        </div>
    );
};

export default ChucDanhPhongBanComponent;
